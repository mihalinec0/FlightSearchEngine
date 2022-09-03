using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Link
    {
        [JsonPropertyName("self")]
        public string? Self { get; set; }
    }
}
