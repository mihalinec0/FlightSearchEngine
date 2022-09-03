using DAL.Models;
using FlightSearchEngine.JsonResponsModels;

namespace FlightSearchEngine.Utilities
{
    public static class JsonUtilities
    {
        public static List<FlightSearchResult>? ParseJsonResponToDatabaseObject(List<Data> jsonData)
        {
            var flightSearchResult = new List<FlightSearchResult>();

            foreach (var singleData in jsonData)
            {
                var itinerarie = singleData.Itineraries?.FirstOrDefault();

                var segmentsList = itinerarie?.Segments?.ToList();

                var numberOfSegments = segmentsList == null ? 0 : segmentsList.Count();

                var departureAirport = segmentsList?.FirstOrDefault()?.Departure;
                var arivalAirport = segmentsList?.LastOrDefault()?.Arrival;
                var numberOfTransfers = numberOfSegments == 0 ? 0 : numberOfSegments - 1;
                var price = singleData.Price;
                var travelerPricings = singleData?.TravelerPricings?.ToList();


                flightSearchResult.Add(new FlightSearchResult
                {
                    DepartureAirport = departureAirport?.IataCode,
                    DepartureDate = departureAirport?.At == null ? null : Convert.ToDateTime(departureAirport?.At),
                    ArivalAirport = arivalAirport?.IataCode,
                    ArivalDate = arivalAirport?.At == null ? null : Convert.ToDateTime(arivalAirport?.At),
                    Currency = price?.Currency,
                    NumberOfPassengers = travelerPricings.Count(),
                    TotalPrice = price?.Total,
                    NumberOfTransfers = numberOfTransfers,


                });



            }

            return flightSearchResult;
        }

    }
}

