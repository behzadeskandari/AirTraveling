using System;

namespace FlightReservation.Core.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationDate { get; set; }
        public Flight Flight { get; set; }
    }
}
