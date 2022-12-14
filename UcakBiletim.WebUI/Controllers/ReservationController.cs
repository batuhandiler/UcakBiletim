using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UcakBiletim.Business.Services.Reservations;
using UcakBiletim.Entities.Concrete;
using UcakBiletim.WebUI.CustomExtensions;
using UcakBiletim.WebUI.Models.Flights;

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
            var userId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
            var reservations = _reservationService.GetReservationsByUserId(userId);

            ViewBag.Reservations = reservations;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveReservation(ReservationViewModel reservationViewModel, string[] passengers)
        {
            if (reservationViewModel.DepartureFlightId == 0)
            {
                return BadRequest("DepertureFlightIdNull");
            }

            if (string.IsNullOrEmpty(reservationViewModel.PassengerName) ||
                string.IsNullOrEmpty(reservationViewModel.PassengerSurname) ||
                string.IsNullOrEmpty(reservationViewModel.PassengerEmail))
            {
                return BadRequest("PassengerNull");
            }

            if (string.IsNullOrEmpty(reservationViewModel.CreditCardHolderName) ||
                string.IsNullOrEmpty(reservationViewModel.CreditCardNo) ||
                string.IsNullOrEmpty(reservationViewModel.CreditCardCvc))
            {
                return BadRequest("CreditCardNull");
            }

            var reservationList = new List<Reservation>();

            if (passengers[0] != null)
            {
                var passengersSplit = passengers[0].Split(',');

                foreach (var item in passengersSplit)
                {
                    var passengerSplit = item.Split(";");
                    var passengerName = passengerSplit[0];
                    var passengerSurname = passengerSplit[1];
                    var passengerMail = passengerSplit[2];

                    if (string.IsNullOrEmpty(passengerName) ||
                        string.IsNullOrEmpty(passengerSurname) ||
                        string.IsNullOrEmpty(passengerMail))
                    {
                        return BadRequest("PassengerNull");
                    }
                }

                foreach (var item in passengersSplit)
                {
                    var passengerSplit = item.Split(";");
                    var passengerName = passengerSplit[0];
                    var passengerSurname = passengerSplit[1];
                    var passengerMail = passengerSplit[2];

                    var reservation = new Reservation
                    {
                        UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                        ReservationNo = Guid.NewGuid(),
                        DepartureFlightId = reservationViewModel.DepartureFlightId,
                        ReturnFlightId = reservationViewModel.ReturnFlightId,
                        CabinClass = reservationViewModel.CabinClass,
                        PassengerName = passengerName,
                        PassengerSurname = passengerSurname,
                        PassengerEmail = passengerMail,
                        CreditCardHolderName = reservationViewModel.CreditCardHolderName,
                        CreditCardNo = reservationViewModel.CreditCardNo,
                        CreditCardCvc = reservationViewModel.CreditCardCvc,
                        CreditCardExpirationDate = reservationViewModel.CreditCardExpirationDate,
                        Price = reservationViewModel.Price
                    };

                    if (reservation.ReturnFlightId == 0)
                        reservation.ReturnFlightId = null;

                    await _reservationService.AddAsync(reservation);
                    reservationList.Add(reservation);
                }
            }

            var mainReservation = new Reservation
            {
                UserId = Convert.ToInt32(HttpContext.Session.GetInt32("UserId")),
                ReservationNo = Guid.NewGuid(),
                DepartureFlightId = reservationViewModel.DepartureFlightId,
                ReturnFlightId = reservationViewModel.ReturnFlightId,
                CabinClass = reservationViewModel.CabinClass,
                PassengerName = reservationViewModel.PassengerName,
                PassengerSurname = reservationViewModel.PassengerSurname,
                PassengerEmail = reservationViewModel.PassengerEmail,
                CreditCardHolderName = reservationViewModel.CreditCardHolderName,
                CreditCardNo = reservationViewModel.CreditCardNo,
                CreditCardCvc = reservationViewModel.CreditCardCvc,
                CreditCardExpirationDate = reservationViewModel.CreditCardExpirationDate,
                Price = reservationViewModel.Price
            };

            if (mainReservation.ReturnFlightId == 0)
                mainReservation.ReturnFlightId = null;

            await _reservationService.AddAsync(mainReservation);
            reservationList.Add(mainReservation);

            return Ok(reservationList);
        }

        public async Task<IActionResult> DeleteReservation(int reservationId)
        {
            if (reservationId != 0)
            {
                try
                {
                    await _reservationService.DeleteByIdAsync(reservationId);
                }
                catch (Exception exception)
                {
                    return BadRequest();
                }

                return Ok();
            }
            else
                return BadRequest();
        }

        public IActionResult CheckReservationByNo(Guid reservationNo)
        {
            if (string.IsNullOrEmpty(reservationNo.ToString()) ||
                reservationNo.ToString() == "00000000-0000-0000-0000-000000000000")
                return BadRequest("ReservationNoNull");

            var reservation = _reservationService.GetReservationByReservationNo(reservationNo);

            if (reservation is null)
                return BadRequest("ReservationNull");

            HttpContext.Session.Set<Reservation>("Reservation", reservation);

            return Ok();
        }

        public IActionResult CheckReservation()
        {
            var reservation = HttpContext.Session.Get<Reservation>("Reservation");

            return View(reservation);
        }

        public IActionResult GetCheckReservationPartial()
        {
            return PartialView("~/Views/Shared/Partials/_CheckReservation.cshtml");
        }
    }
}
