using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Departure
    {
        [JsonPropertyName("iataCode")]
        public string IataCode { get; set; } = null!;
        [JsonPropertyName("terminal")]
        public string Terminal { get; set; } = null!;
        [JsonPropertyName("at")]
        public string At { get; set; } = null!;

    }
}
