using DAL;
using DAL.Models;
using FlightSearchEngine.Constants;
using FlightSearchEngine.Interfaces;
using FlightSearchEngine.JsonResponsModels;
using FlightSearchEngine.Models;
using FlightSearchEngine.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace FlightSearchEngine.Implementations
{
    public class HttpServices : IHttpServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HttpServices> _logger;
        private readonly FlightSearchEngineDbContext _dbContext;
        public HttpServices(IHttpClientFactory httpClientFactory, ILogger<HttpServices> logger, FlightSearchEngineDbContext dbContext)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _dbContext = dbContext;
        }

        public StringContent HttpContent(string content, Encoding encoding, string mediaType)
        {
            return new StringContent(content, encoding, mediaType);
        }

        public string ConstructTokenContent(string formatString, string grantType, string client_id, string client_secret)
        {

            var content = String.Format(formatString, grantType, client_id, client_secret);

            return content;

        }

        public async Task<List<FlightSearchResult>> GetDataAsync(string queryFilter)
        {
            var data = new List<FlightSearchResult>();

            try
            {
                var castedFilter = QueryStringUtilities.CastQueryFilterToDictionary(queryFilter);


                var filterFromDatabase = await GetFilterFromDatabase(queryStringDictionary: castedFilter);

                if (filterFromDatabase != null)
                {

                    data = await _dbContext.FlightSearchResults
                          .Where(fk => fk.FlightSearchFilterId == filterFromDatabase.Id)
                          .AsNoTracking()
                          .ToListAsync();

                }
                else
                {
                    var accessToken = await GrantAccessTokenAsync(
                                            clientId: HttpClientConstants.ClientId,
                                            clientSecret: HttpClientConstants.ClientSecret
                                            );

                    if (string.IsNullOrEmpty(accessToken))
                    {

                        _logger.LogInformation("Token is empty, request aborted!");

                        return data;

                    }
                    else
                    {

                        _logger.LogInformation("Token token successfully created");

                        var httpClient = _httpClientFactory.CreateClient(HttpClientConstants.HttpGetDataClient);

                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(HttpClientConstants.TokenType, accessToken);

                        var requestQueryStringWithoutNullValues = QueryStringUtilities.FilterOutNullValuePairs(dictionary: castedFilter);

                        var requestQueryString = QueryStringUtilities.GetQueryString(keyValuePairs: requestQueryStringWithoutNullValues);


                        var respose = await httpClient.GetAsync(
                            requestUri: HttpClientConstants.GetFlightsDataLink + requestQueryString);

                        respose.EnsureSuccessStatusCode();

                        _logger.LogInformation("Data for the given conditions has been successfully retrieved.");

                        var resposeData = await respose.Content.ReadAsStringAsync();

                        var doc = JsonDocument.Parse(resposeData);

                        var dataProperty = doc.RootElement.GetProperty("data");

                        var jsonData = JsonSerializer.Deserialize<List<Data>>(dataProperty);

                        data = JsonUtilities.ParseJsonResponToDatabaseObject(jsonData: jsonData);

                        await SaveFilterAndResultsToDatabase(queryDictionary: castedFilter, flightSearchResults: data);

                    }
                }

                return data;
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);

                return new List<FlightSearchResult>();
            }
        }

        public async Task<string?> GrantAccessTokenAsync(string clientId, string clientSecret)
        {
            try
            {
                var content = ConstructTokenContent(
              formatString: HttpClientConstants.HttpClientAuthorizationContent,
              grantType: HttpClientConstants.GrantType,
              client_id: clientId,
              client_secret: clientSecret
              );

                var httpContent = HttpContent(
                    content: content,
                    Encoding.UTF8,
                    mediaType: HttpClientConstants.AccessTokenMediaType
                );

                var httpClient = _httpClientFactory.CreateClient(HttpClientConstants.HttpAuthorizationClient);
                var respose = await httpClient.PostAsync(
                    requestUri: HttpClientConstants.AuthorizationLink,
                    content: httpContent
                    );

                respose.EnsureSuccessStatusCode();

                var resposneData = await respose.Content.ReadAsStringAsync();
                var json = JsonSerializer.Deserialize<AccessTokenModel>(resposneData);
                var accessToken = json?.Access_token;


                return accessToken;
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);

                return "";
            }

        }

        private async Task<FlightSearchFilter>? GetFilterFromDatabase(Dictionary<string, string> queryStringDictionary)
        {


            var originCode = queryStringDictionary["originLocationCode"] == "" ? "NULL" : queryStringDictionary["originLocationCode"];
            var destinationCode = queryStringDictionary["destinationLocationCode"] == "" ? "NULL" : queryStringDictionary["destinationLocationCode"];
            var departureDate = queryStringDictionary["departureDate"] == "" ? "NULL" : queryStringDictionary["departureDate"];
            var returnDate = queryStringDictionary["returnDate"] == "" ? "NULL" : queryStringDictionary["returnDate"];
            var currencyCode = queryStringDictionary["currencyCode"] == "" ? "NULL" : queryStringDictionary["currencyCode"];
            var adults = queryStringDictionary["adults"] == "" ? 0 : Convert.ToInt32(queryStringDictionary["adults"]);
            var children = queryStringDictionary["children"] == "" ? 0 : Convert.ToInt32(queryStringDictionary["children"]);
            var infants = queryStringDictionary["infants"] == "" ? 0 : Convert.ToInt32(queryStringDictionary["infants"]);


            var filter = _dbContext.FlightSearchFilters.FromSqlInterpolated($"sp_GetFilter @originCode={originCode},@destinationCode={destinationCode},@departureDate={departureDate},@returnDate={returnDate},@currencyCode={currencyCode},@adults={adults},@children={children},@infants={infants}");


            var filterList = await filter.ToListAsync();

            return filterList.LastOrDefault();
        }

        private async Task SaveFilterAndResultsToDatabase(Dictionary<string, string> queryDictionary, List<FlightSearchResult> flightSearchResults)
        {
            try
            {
                var adults = queryDictionary["adults"] == "" ? 0 : Convert.ToInt32(queryDictionary["adults"]);
                var children = queryDictionary["children"] == "" ? 0 : Convert.ToInt32(queryDictionary["children"]);
                var infants = queryDictionary["infants"] == "" ? 0 : Convert.ToInt32(queryDictionary["infants"]);
                var returnDate = queryDictionary["returnDate"] == "" ? "NULL" : queryDictionary["returnDate"];
                var currencyCode = queryDictionary["currencyCode"] == "" ? "NULL" : queryDictionary["currencyCode"];


                var filterDto = new FlightSearchFilter()
                {

                    OriginLocationCode = queryDictionary["originLocationCode"],
                    DestinationLocationCode = queryDictionary["destinationLocationCode"],
                    DepartureDate = queryDictionary["departureDate"],
                    ReturnDate = returnDate,
                    CurrencyCode = currencyCode,
                    Adults = adults,
                    Children = children,
                    Infants = infants,
                    FlightSearchResults = flightSearchResults

                };

                _dbContext.FlightSearchFilters.Add(filterDto);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                _logger.LogError(e.Message);

            }


        }

    }
}
