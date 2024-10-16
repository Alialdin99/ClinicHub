using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ClinicSystem.Models
{
    public class Doctor 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int Salary { get; set; }
        public int ExperienceYears { get; set; }
        
        [ForeignKey("Clinic")]
        public int ClinicId { get; set; }
        public virtual Clinic? Clinic { get; set; }
        public List<Reservation> Reservations { get; set; }

    }

}
