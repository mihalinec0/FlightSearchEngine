using System.Text.Json.Serialization;

namespace FlightSearchEngine.Models
{
    public class AccessTokenModel
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("username")]
        public string? Username { get; set; }
        [JsonPropertyName("application_name")]
        public string? Application_name { get; set; }
        [JsonPropertyName("access_token")]
        public string? Access_token { get; set; }
        [JsonPropertyName("client_id")]
        public string? Client_id { get; set; }
        [JsonPropertyName("token_type")]
        public string? Token_type { get; set; }
        [JsonPropertyName("expires_in")]
        public int? Expires_in { get; set; }
        [JsonPropertyName("state")]
        public string? State { get; set; }
        [JsonPropertyName("scope")]
        public string? Scope { get; set; }
    }
}
