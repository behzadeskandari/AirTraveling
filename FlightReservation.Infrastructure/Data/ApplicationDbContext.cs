using FlightReservation.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FlightReservation.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
    }
}

