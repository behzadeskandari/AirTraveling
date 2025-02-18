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
    public class SearchFlightsQueryHandler : IRequestHandler<SearchFlightsQuery, IEnumerable<FlightDto>>
    {
        private readonly IGenericRepository<FlightReservation.Core.Entities.Flight> _flightRepository;
        private readonly IMapper _mapper;

        public SearchFlightsQueryHandler(IGenericRepository<FlightReservation.Core.Entities.Flight> flightRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FlightDto>> Handle(SearchFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _flightRepository.FindAsync(f =>
                f.DepartureCity == request.DepartureCity &&
                f.ArrivalCity == request.ArrivalCity &&
                f.DepartureTime.Date == request.DepartureDate.Date);

            return _mapper.Map<IEnumerable<FlightDto>>(flights);
        }
    }
}