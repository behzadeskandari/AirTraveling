using FlightReservation.Application.DTOs;
using FluentResults;
using MediatR;

namespace FlightReservation.Application.Feature.Flight.Commands
{
    public class BookFlightCommand : IRequest<Result>
    {
        public int FlightId { get; set; }
        public string UserId { get; set; }
    }
}