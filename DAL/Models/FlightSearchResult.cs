using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class FlightSearchResult
    {
        public int Id { get; set; }
        public string? DepartureAirport { get; set; }

        public DateTime? DepartureDate { get; set; }
        public string? ArivalAirport { get; set; }
        public DateTime? ArivalDate { get; set; }
        public string? Currency { get; set; }
        public int NumberOfPassengers { get; set; }
        public int NumberOfTransfers { get; set; }
        public string? TotalPrice { get; set; }
        public int FlightSearchFilterId { get; set; }
        public FlightSearchFilter FlightSearchFilter { get; set; } = null!;
    }
}
