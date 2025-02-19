using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FlightReservation.Application.DTOs;
using FlightReservation.Application.Services;
using FlightReservation.Core.Entities;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace FlightReservation.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper, IJwtService jwtService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<Result<string>> ForgotPasswordAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Result.Fail("User not found");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            // In a real-world scenario, you would send this token to the user's email
            // For this example, we'll just return it
            return Result.Ok(token);
        }

        public async Task<Result<string>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Result.Fail("User not found");
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
            {
                return Result.Fail("Invalid password");
            }

            var claimsIdentity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            });

            var tokenString = _jwtService.GenerateToken(claimsIdentity);

            return Result.Ok(tokenString);
        }

        public async Task<Result> RegisterAsync(RegisterDto registerDto)
        {
            var user = await _userManager.FindByNameAsync(registerDto.UserName);
            if (user != null)
            {
                return Result.Fail("User Already Exists");
            }

            user = new ApplicationUser
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return Result.Fail(result.Errors.Select(e => e.Description));
            }

            // Optionally, you can add roles to the user here
            // await _userManager.AddToRoleAsync(user, "User");

            return Result.Ok();
        }

        public async Task<Result> ResetPasswordAsync(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
            {
                return Result.Fail("User not found");
            }

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                return Result.Fail(result.Errors.Select(e => e.Description));
            }

            return Result.Ok();
        }
    }
}

