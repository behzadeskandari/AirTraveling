using System.Security.Claims;

namespace FlightReservation.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(ClaimsIdentity claimsIdentity);
    }
}