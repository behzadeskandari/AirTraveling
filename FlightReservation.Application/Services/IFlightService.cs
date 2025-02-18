using System.Collections.Generic;
using System.Threading.Tasks;
using FlightReservation.Application.DTOs;
using FluentResults;

namespace FlightReservation.Application.Services
{
    public interface IFlightService
    {
        Task<IEnumerable<FlightDto>> SearchFlightsAsync(SearchFlightsDto searchFlightsDto);
        Task<Result> BookFlightAsync(BookFlightDto bookFlightDto);
        Task<IEnumerable<ReservationDto>> GetBookingHistoryAsync(string userId);
    }
}