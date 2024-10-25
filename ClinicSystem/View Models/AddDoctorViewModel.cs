using System.ComponentModel.DataAnnotations;
using ClinicSystem.Models;

namespace ClinicSystem.View_Models
{
    public class AddDoctorViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public int ExperienceYears { get; set; }

        [Required]
        public int ClinicId { get; set; }
        public List<Clinic> Clinics { get; set; }
    }
}