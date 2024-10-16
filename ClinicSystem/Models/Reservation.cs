namespace ClinicSystem.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int ClinicId { get; set; }
        public Clinic Clinic { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
    }

}
