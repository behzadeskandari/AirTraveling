using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FlightReservation.Application.DTOs;
using FlightReservation.Application.Services;
using FlightReservation.Core.Entities;
using FlightReservation.Core.Interfaces;
using FluentResults;

namespace FlightReservation.Infrastructure.Services
{
    public class FlightService : IFlightService
    {
        private readonly IGenericRepository<Flight> _flightRepository;
        private readonly IGenericRepository<Reservation> _reservationRepository;
        private readonly IMapper _mapper;

        public FlightService(IGenericRepository<Flight> flightRepository, IGenericRepository<Reservation> reservationRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightDto>> SearchFlightsAsync(SearchFlightsDto searchFlightsDto)
        {
            var flights = await _flightRepository.FindAsync(f =>
                f.DepartureCity == searchFlightsDto.DepartureCity &&
                f.ArrivalCity == searchFlightsDto.ArrivalCity &&
                f.DepartureTime.Date == searchFlightsDto.DepartureDate.Date);

            return _mapper.Map<IEnumerable<FlightDto>>(flights);
        }

        public async Task<Result> BookFlightAsync(BookFlightDto bookFlightDto)
        {
            var reservation = new Reservation
            {
                FlightId = bookFlightDto.FlightId,
                UserId = bookFlightDto.UserId,
                ReservationDate = DateTime.UtcNow
            };

            await _reservationRepository.AddAsync(reservation);
            return Result.Ok();
        }

        public async Task<IEnumerable<ReservationDto>> GetBookingHistoryAsync(string userId)
        {
            var reservations = await _reservationRepository.FindAsync(r => r.UserId == userId);
            return _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        }
    }
}