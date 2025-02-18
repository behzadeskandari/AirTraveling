using System.Collections.Generic;
using System.Threading.Tasks;
using FlightReservation.Application.DTOs;
using FlightReservation.Application.Feature.Flight.Commands;
using FlightReservation.Application.Feature.Flight.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightReservation.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<FlightDto>>> SearchFlights([FromQuery] SearchFlightsDto searchFlightsDto)
        {
            var query = new SearchFlightsQuery
            {
                DepartureCity = searchFlightsDto.DepartureCity,
                ArrivalCity = searchFlightsDto.ArrivalCity,
                DepartureDate = searchFlightsDto.DepartureDate
            };

            var flights = await _mediator.Send(query);
            return Ok(flights);
        }

        [HttpPost("book")]
        [Authorize]
        public async Task<IActionResult> BookFlight([FromBody] BookFlightDto bookFlightDto)
        {
            var command = new BookFlightCommand
            {
                FlightId = bookFlightDto.FlightId,
                UserId = bookFlightDto.UserId
            };

            var result = await _mediator.Send(command);
            if (result.IsFailed)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { Message = "Flight booked successfully." });
        }

        [HttpGet("history")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ReservationDto>>> GetBookingHistory([FromQuery] string userId)
        {
            var query = new GetBookingHistoryQuery { UserId = userId };
            var reservations = await _mediator.Send(query);
            return Ok(reservations);
        }
    }
}

