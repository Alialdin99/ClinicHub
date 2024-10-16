using Microsoft.AspNetCore.Identity;

namespace ClinicSystem.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Reservation> Reservations { get; set; }
    }

}
