
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FlightSearchEngine.JsonResponsModels
{
    public class Itineraries
    {
        [JsonPropertyName("duration")]
        public string? Duration { get; set; }
        [JsonPropertyName("segments")]
        public IList<Segment>? Segments { get; set; }
      
    }
}
