using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UcakBiletim.Business.Services.Flights;
using UcakBiletim.Business.Services.Reservations;
using UcakBiletim.Entities.Concrete;
using UcakBiletim.WebUI.CustomExtensions;
using UcakBiletim.WebUI.Models.Flights;

namespace UcakBiletim.WebUI.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private readonly IReservationService _reservationService;

        public FlightController(IFlightService flightService, IReservationService reservationService)
        {
            _flightService = flightService;
            _reservationService = reservationService;
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
            ViewBag.DepartureFlights = resultFlights.DepartureFlights;
            ViewBag.ReturnFlights = resultFlights.ReturnFlights;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveReservation(ReservationViewModel reservationViewModel)
        {
            var reservation = new Reservation
            {
                UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                DepartureFlightId = reservationViewModel.DepartureFlightId,
                ReturnFlightId = reservationViewModel.ReturnFlightId,
                PassengerName = reservationViewModel.PassengerName,
                PassengerSurname = reservationViewModel.PassengerSurname,
                PassengerEmail = reservationViewModel.PassengerEmail,
                CreditCardHolderName = reservationViewModel.CreditCardHolderName,
                CreditCardNo = reservationViewModel.CreditCardNo,
                CreditCardCvc = reservationViewModel.CreditCardCvc,
                CreditCardExpirationDate = reservationViewModel.CreditCardExpirationDate
            };

            await _reservationService.AddAsync(reservation);

            return Ok();
        }
    }
}
