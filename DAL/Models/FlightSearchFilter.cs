using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models

{
    public class FlightSearchFilter
    {
        public int Id { get; set; }
        public string? OriginLocationCode { get; set; }
        public string? DestinationLocationCode { get; set; }
        public string? DepartureDate { get; set; }
        public string? ReturnDate { get; set; }
        public string? CurrencyCode { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public int? Infants { get; set; }
        
        public IList<FlightSearchResult> FlightSearchResults { get; set; } = null!;

    }
}
