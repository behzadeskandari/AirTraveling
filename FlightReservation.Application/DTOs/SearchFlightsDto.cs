namespace FlightReservation.Application.DTOs
{
    public class SearchFlightsDto
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}