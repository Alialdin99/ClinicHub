using ClinicSystem.DataContext;
using ClinicSystem.Models;
using ClinicSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace ClinicSystem.Services
{
    public class ReservationService
    {
        public readonly IReservationRepository _repository;
        private readonly TimeSpan SlotDuration = TimeSpan.FromMinutes(30);
        private readonly TimeSpan StartTime = TimeSpan.FromHours(9);
        private readonly TimeSpan EndTime = TimeSpan.FromHours(17);
        public ReservationService(IReservationRepository repository)
        {
            _repository = repository;
        }

        public List<Reservation> GetAll()
        {
            List<Reservation> reservations = _repository.GetAll();
            return reservations;
        }

        public Reservation GetById(int id)
        {
            Reservation reservation = _repository.GetById(id);
            return reservation;
        }

        public bool Add(Reservation reservation)
        {
            return _repository.Add(reservation);
        }

        public bool Update(Reservation reservation)
        {
            return _repository.Update(reservation);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool MakeReservation(string userId, int doctorId,int ClinicId , DateTime appointmenTime)
        {
            bool isAvaliable = _repository.IsAvaliable(doctorId, appointmenTime);
            if (isAvaliable)
            {
                var reservation = new Reservation
                {
                    UserId = userId,
                    DoctorId = doctorId,
                    ClinicId = ClinicId,
                    AppointmentDate = appointmenTime,
                    Status = "Confirmed"
                };
                _repository.Add(reservation);
                return true;
            }
            return isAvaliable;
        }
        public List<DateTime> GetAvailableSlots(int doctorId, DateTime date)
        {
            List<DateTime> allSlots = new List<DateTime>();
            DateTime currentSlot = date.Date.Add(StartTime);
            DateTime endOfDay = date.Date.Add(EndTime);

            while (currentSlot < endOfDay)
            {
                allSlots.Add(currentSlot);
                currentSlot = currentSlot.Add(SlotDuration);
            }

            var reservedSlots = _repository.getReservedSlots(doctorId, date);

            return allSlots.Except(reservedSlots).ToList();
        }

        public void DeleteAllReservations()
        {
            _repository.DeleteAll();
        }



    }
}
