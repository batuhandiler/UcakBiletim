using System.Collections.Generic;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.WebUI.Models.Flights
{
    public class ResultFlights
    {
        public string OneWayRoundTrip { get; set; }
        public string CabinClass { get; set; }
        public List<Flight> DepartureFlights { get; set; }
        public List<Flight> ReturnFlights { get; set; }
    }
}
