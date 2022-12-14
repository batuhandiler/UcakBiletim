﻿using Microsoft.AspNetCore.Http;
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
                    DepartureFlights = departureFlights,
                    ReturnFlights = returnFligts,
                };

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

            ViewBag.DepartureFlights = resultFlights.DepartureFlights;
            ViewBag.ReturnFlights = resultFlights.ReturnFlights;

            return View();
        }
    }
}