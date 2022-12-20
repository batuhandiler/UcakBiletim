namespace UcakBiletim.WebUI.Models.Flights
{
    public class ReservationViewModel
    {
        public int DepartureFlightId { get; set; }
        public int ReturnFlightId { get; set; }
        public string CabinClass { get; set; }
        public string PassengerName { get; set; }
        public string PassengerSurname { get; set; }
        public string PassengerEmail { get; set; }
        public string CreditCardHolderName { get; set; }
        public string CreditCardNo { get; set; }
        public string CreditCardCvc { get; set; }
        public string CreditCardExpirationDate { get; set; }
    }
}
