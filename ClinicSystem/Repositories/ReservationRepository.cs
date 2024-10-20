using ClinicSystem.DataContext;
using ClinicSystem.Models;
using ClinicSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClinicSystem.Repositories
{
    public class ReservationRepository:IReservationRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly TimeSpan SlotDuration = TimeSpan.FromMinutes(30);
        private readonly TimeSpan StartTime = TimeSpan.FromHours(9);  
        private readonly TimeSpan EndTime = TimeSpan.FromHours(17);

        public ReservationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservation = _dbContext.Reservations.ToList();
            return reservation;
        }
        public Reservation GetById(int id)
        {
            Reservation reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            return reservation;
        }
        public bool Add(Reservation entity)
        {
            _dbContext.Reservations.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Reservation entity)
        {
            _dbContext.Reservations.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Reservation reservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);
            _dbContext.Remove(reservation);
            return _dbContext.SaveChanges() > 0;
        }

        public bool IsAvaliable(int doctorId, DateTime appointmentTime)
        {
           var result =  !_dbContext.Reservations.Any(r => r.DoctorId == doctorId && r.AppointmentDate == appointmentTime);
            return result;
        }

        public List<DateTime> GetReservedSlots(int doctorId, DateTime date)
        {
            var reservedSlots = _dbContext.Reservations
                .Where(r => r.DoctorId == doctorId && r.AppointmentDate.Date == date.Date)
                .Select(r => r.AppointmentDate)
                .ToList();
            return reservedSlots;
        }
        public List<DateTime> GetSlotsForDay(int doctorId, DateTime date)
        {
            
            List<DateTime> allSlots = new List<DateTime>();
            DateTime currentSlot = date.Date.Add(StartTime);  
            DateTime endOfDay = date.Date.Add(EndTime);     

            while (currentSlot < endOfDay)
            {
                allSlots.Add(currentSlot);
                currentSlot = currentSlot.Add(SlotDuration);
            }

            var reservedSlots = _dbContext.Reservations
                .Where(r => r.DoctorId == doctorId && r.AppointmentDate.Date == date.Date)
                .Select(r => r.AppointmentDate)
                .ToList();

            var availableSlots = allSlots.Except(reservedSlots).ToList();
            return availableSlots;
        }

        public void DeleteAll()
        {
            var allReservations = _dbContext.Reservations.ToList();
            _dbContext.Reservations.RemoveRange(allReservations);
            _dbContext.SaveChanges();
        }
    }
}
