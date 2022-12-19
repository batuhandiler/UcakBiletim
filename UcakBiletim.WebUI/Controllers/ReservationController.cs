using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using UcakBiletim.Entities.Concrete;
using UcakBiletim.WebUI.Models.Flights;
using UcakBiletim.Business.Services.Reservations;
using UcakBiletim.Business.Services.Flights;

namespace UcakBiletim.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index()
        {
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
