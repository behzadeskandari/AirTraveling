using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FlightReservation.Application.DTOs;
using FlightReservation.Application.Feature.Flight.Queries;
using FlightReservation.Core.Entities;
using FlightReservation.Core.Interfaces;
using MediatR;

namespace FlightReservation.Application.Flights.Handlers
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, IEnumerable<FlightDto>>
    {
        private readonly IGenericRepository<Flight> _flightRepository;
        private readonly IMapper _mapper;

        public GetFlightsQueryHandler(IGenericRepository<Flight> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightDto>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.FindAsync(f =>
                f.DepartureCity == request.DepartureCity &&
                f.ArrivalCity == request.ArrivalCity &&
                f.DepartureTime.Date == request.DepartureDate.Date);

            return _mapper.Map<IEnumerable<FlightDto>>(flights);
        }
    }
}
