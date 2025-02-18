using Microsoft.AspNetCore.Identity;

namespace FlightReservation.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

    }
}

