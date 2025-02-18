using System.Collections.Generic;
using FlightReservation.Application.DTOs;
using MediatR;

namespace FlightReservation.Application.Feature.Flight.Queries
{
    public class GetBookingHistoryQuery : IRequest<IEnumerable<ReservationDto>>
    {
        public string UserId { get; set; }
    }
}