using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Arrival
    {
        [JsonPropertyName("iataCode")]
        public string? IataCode { get; set; }
        [JsonPropertyName("terminal")]
        public string? Terminal { get; set; }
        [JsonPropertyName("at")]
        public DateTime? At { get; set; }
    }
}
