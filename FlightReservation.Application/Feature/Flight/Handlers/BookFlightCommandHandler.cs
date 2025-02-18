using System.Threading;
using System.Threading.Tasks;
using FlightReservation.Application.DTOs;
using FlightReservation.Application.Feature.Flight.Commands;
using FlightReservation.Core.Entities;
using FlightReservation.Core.Interfaces;
using FluentResults;
using MediatR;

namespace FlightReservation.Application.Feature.Flight.Handlers
{
    public class BookFlightCommandHandler : IRequestHandler<BookFlightCommand, Result>
    {
        private readonly IGenericRepository<Reservation> _reservationRepository;

        public BookFlightCommandHandler(IGenericRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<Result> Handle(BookFlightCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Reservation
            {
                FlightId = request.FlightId,
                UserId = request.UserId,
                ReservationDate = DateTime.UtcNow
            };

            await _reservationRepository.AddAsync(reservation);
            return Result.Ok();
        }
    }
}