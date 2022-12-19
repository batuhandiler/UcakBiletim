﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UcakBiletim.Business.Services.Reservations;
using UcakBiletim.Entities.Concrete;
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
        public async Task<IActionResult> SaveReservation(ReservationViewModel reservationViewModel)
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
    }
}
