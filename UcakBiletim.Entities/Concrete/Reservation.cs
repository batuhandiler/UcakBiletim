using System;
using UcakBiletim.Core.Entities;

namespace UcakBiletim.Entities.Concrete
{
    public class Reservation : IEntity
    {
        public int Id { get; set; }
        public Guid ReservationNo { get; set; }
        public int UserId { get; set; }
        public int DepartureFlightId { get; set; }
        public int ReturnFlightId { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
        public string PassengerEmail { get; set; }
        public string CreditCardHolderName { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardCvc { get; set; }
        public string CreditCardExpirationDate { get; set; }

        public Flight DepartureFlight { get; set; }
        public Flight ReturnFlight { get; set; }
    }
}
