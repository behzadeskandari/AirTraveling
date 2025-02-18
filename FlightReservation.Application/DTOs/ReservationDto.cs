namespace FlightReservation.Application.DTOs
{
    public class ReservationDto
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}