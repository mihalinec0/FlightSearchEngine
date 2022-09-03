using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Segment
    {
        [JsonPropertyName("arrival")]
        public Arrival? Arrival { get; set; }
        [JsonPropertyName("departure")]
        public Departure? Departure { get; set; }
    }
}
