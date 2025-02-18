using FlightReservation.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservation.Application.Feature.Flight.Queries
{
    public class GetFlightsQuery : IRequest<IEnumerable<FlightDto>>
    {
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
