using ClinicSystem.Models;

namespace ClinicSystem.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        List<Reservation> GetAll();
        Reservation GetById(int id);
        bool Add(Reservation entity);
        bool Update(Reservation entity);
        bool Delete(int id);
        public bool IsAvaliable(int doctorId, DateTime appointmentTime);
        public List<DateTime> getReservedSlots(int doctorId, DateTime date);
        public void DeleteAll();
    }
}
