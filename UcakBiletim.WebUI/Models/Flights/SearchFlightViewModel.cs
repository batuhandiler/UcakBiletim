using System;

namespace UcakBiletim.WebUI.Models.Flights
{
    public class SearchFlightViewModel
    {
        public string OneWayRoundTrip { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
