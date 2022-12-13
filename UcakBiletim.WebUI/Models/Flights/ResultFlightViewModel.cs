using System.Collections.Generic;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.WebUI.Models.Flights
{
    public class ResultFlightViewModel
    {
        public List<Flight> DepartureFlights { get; set; }
        public List<Flight> ReturnFlights { get; set; }
    }
}
