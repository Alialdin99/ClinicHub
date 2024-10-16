namespace ClinicSystem.Models
{
    public class Clinic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
