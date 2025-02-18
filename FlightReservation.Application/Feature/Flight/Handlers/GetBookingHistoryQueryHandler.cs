using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightReservation.Application.DTOs;
using FlightReservation.Application.Feature.Flight.Queries;
using FlightReservation.Core.Entities;
using FlightReservation.Core.Interfaces;
using MediatR;

namespace FlightReservation.Application.Feature.Flight.Handlers
{
    public class GetBookingHistoryQueryHandler : IRequestHandler<GetBookingHistoryQuery, IEnumerable<ReservationDto>>
    {
        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;

        public GetBookingHistoryQueryHandler(IGenericRepository<Reservation> reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationDto>> Handle(GetBookingHistoryQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.FindAsync(r => r.UserId == request.UserId);
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }
}