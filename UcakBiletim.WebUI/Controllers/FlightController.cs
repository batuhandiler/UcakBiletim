using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using UcakBiletim.Business.Services.Flights;
using UcakBiletim.WebUI.CustomExtensions;
using UcakBiletim.WebUI.Models.Flights;

namespace UcakBiletim.WebUI.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        public IActionResult SearchFlight(SearchFlightViewModel searchFlightViewModel)
        {
            if (searchFlightViewModel is null)
                return BadRequest();

            try
            {
                var departureFlights = _flightService.GetDepartureFlights(searchFlightViewModel.From, searchFlightViewModel.To, searchFlightViewModel.DepartureDate);
                var returnFligts = _flightService.GetReturnFlights(searchFlightViewModel.To, searchFlightViewModel.From, searchFlightViewModel.ReturnDate);

                var resultFlights = new ResultFlights
                {
                    OneWayRoundTrip = searchFlightViewModel.OneWayRoundTrip,
                    CabinClass = searchFlightViewModel.CabinClass,
                    DepartureFlights = departureFlights,
                    ReturnFlights = returnFligts,
                };

                if (resultFlights.DepartureFlights.Count == 0 || resultFlights.ReturnFlights.Count == 0)
                    return BadRequest("ThereAreNoFlight");

                HttpContext.Session.Set<ResultFlights>("ResultFlights", resultFlights);

                return Ok();
            }
            catch (Exception exception)
            {
                return BadRequest();
            }
        }

        public IActionResult ResultFlight()
        {
            var resultFlights = HttpContext.Session.Get<ResultFlights>("ResultFlights");

            ViewBag.OneWayRoundTrip = resultFlights.OneWayRoundTrip;
            ViewBag.CabinClass = resultFlights.CabinClass;
            ViewBag.DepartureFlights = resultFlights.DepartureFlights;
            ViewBag.ReturnFlights = resultFlights.ReturnFlights;

            return View();
        }

        public IActionResult GetPrice(int flightId, string cabinClass)
        {
            if (flightId != 0)
            {
                var flight = _flightService.GetById(flightId);
                if (flight == null)
                    return BadRequest();
                return Ok(cabinClass == "BusinessClass" ? flight.BusinessClassPrice : flight.EconomyClassPrice);
            }
            return BadRequest();
        }
    }
}
