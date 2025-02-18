using FlightReservation.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentResults;

namespace FlightReservation.Application.Services
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(RegisterDto registerDto);
        Task<Result<string>> LoginAsync(LoginDto loginDto);
        Task<Result<string>> ForgotPasswordAsync(string email);
        Task<Result> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);
    }
}
