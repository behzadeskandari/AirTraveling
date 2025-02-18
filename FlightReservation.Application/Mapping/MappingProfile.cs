using AutoMapper;
using FlightReservation.Application.DTOs;
using FlightReservation.Core.Entities;

namespace FlightReservation.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Reservation, ReservationDto>().ReverseMap();
            CreateMap<ApplicationUser, UserDto>().ReverseMap();
            CreateMap<RegisterDto, ApplicationUser>();
        }
    }
}

