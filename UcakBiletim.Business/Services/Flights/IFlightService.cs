using System;
using System.Collections.Generic;
using UcakBiletim.Entities.Concrete;

namespace UcakBiletim.Business.Services.Flights
{
    public interface IFlightService : IService<Flight>
    {
        List<Flight> GetDepartureFlights(string from, string to, DateTime date);
        List<Flight> GetReturnFlights(string to, string from, DateTime date);
    }
}
