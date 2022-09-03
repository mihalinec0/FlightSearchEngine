using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Meta
    {
        [JsonPropertyName("count")]
        public int?  Count { get; set; }
        [JsonPropertyName("links")]
        public Link? Links { get; set; }
    }
}
