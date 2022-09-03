using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Price
    {
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }
        [JsonPropertyName("total")]
        public string? Total { get; set; }
        
    }
}
