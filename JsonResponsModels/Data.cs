using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearchEngine.JsonResponsModels
{

    public class Data
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("source")]
        public string? Source { get; set; }
        [JsonPropertyName("instantTicketingRequired")]
        public bool InstantTicketingRequired { get; set; }
        [JsonPropertyName("nonHomogeneous")]
        public bool NonHomogeneous { get; set; }
        [JsonPropertyName("oneWay")]
        public bool OneWay { get; set; }
        [JsonPropertyName("lastTicketingDate")]
        public DateTime? LastTicketingDate { get; set; }
        [JsonPropertyName("numberOfBookableSeats")]
        public int? NumberOfBookableSeats { get; set; }
        [JsonPropertyName("itineraries")]
        public List<Itineraries>? Itineraries { get; set; }
        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("travelerPricings")]
        public List<TravelerPricings>? TravelerPricings { get; set; }
    }
}
