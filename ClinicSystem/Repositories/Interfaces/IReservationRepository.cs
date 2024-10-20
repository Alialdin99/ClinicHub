using ClinicSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public List<DateTime> GetSlotsForDay(int doctorId, DateTime date);
        public List<DateTime> GetReservedSlots(int doctorId, DateTime date);
        public void DeleteAll();
    }
}
