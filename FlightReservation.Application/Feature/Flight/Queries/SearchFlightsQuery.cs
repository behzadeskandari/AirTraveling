using System.Collections.Generic;
using FlightReservation.Application.DTOs;
using MediatR;

namespace FlightReservation.Application.Feature.Flight.Queries
{
    public class SearchFlightsQuery : IRequest<IEnumerable<FlightDto>>
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}