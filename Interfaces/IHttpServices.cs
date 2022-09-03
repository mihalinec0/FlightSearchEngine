using DAL.Models;
using FlightSearchEngine.JsonResponsModels;
using FlightSearchEngine.Models;
using System.Text;

namespace FlightSearchEngine.Interfaces
{
    public interface IHttpServices
    {
        Task<List<FlightSearchResult>>GetDataAsync(string queryFilter);
        StringContent HttpContent(string content, Encoding encoding, string mediaType);
        string ConstructTokenContent(string formatString, string grantType, string client_id, string client_secret);

        Task<string?> GrantAccessTokenAsync(string clientId, string clientSecret);
    }
}
