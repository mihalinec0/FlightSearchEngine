namespace FlightSearchEngine.Constants
{
    public class HttpClientConstants
    {
        
        public const string AuthorizationLink = "https://test.api.amadeus.com/v1/security/oauth2/token";
        public const string GetFlightsDataLink = "https://test.api.amadeus.com/v2/shopping/flight-offers?";
        public const string HttpGetDataClient = "HttpGetDataClient";
        public const string HttpAuthorizationClient = "HttpAuthorizationClient";
        public const string GetFlightsDataQueryString = "originLocationCode={0}&destinationLocationCode={1}&departureDate={2}&adults={3}";
        public const string HttpClientAuthorizationContent = "grant_type={0}&client_id={1}&client_secret={2}";
        public const string AccessTokenMediaType = "application/x-www-form-urlencoded";
        public const string MediaType = "application/json";
        public const string GrantType = "client_credentials";
        public const string ClientId = "xARXkGWz8TF3MOF1ZdqFBEYC4MO7NPjg";
        public const string ClientSecret = "ZuIoR141fujbnDrK";
        public const string TokenType = "Bearer";
    }
}
