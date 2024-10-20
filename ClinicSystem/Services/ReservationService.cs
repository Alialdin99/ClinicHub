using ClinicSystem.DataContext;
using ClinicSystem.Models;
using ClinicSystem.Repositories;
using ClinicSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace ClinicSystem.Services
{
    public class ReservationService
    {
        public readonly IReservationRepository _repository;
  
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

        public bool MakeReservation(string userId, int doctorId,int ClinicId , DateTime appointmentTime)
        {
            bool isAvaliable = _repository.IsAvaliable(doctorId, appointmentTime);
            if (isAvaliable)
            {
                var reservation = new Reservation
                {
                    UserId = userId,
                    DoctorId = doctorId,
                    ClinicId = ClinicId,
                    AppointmentDate = appointmentTime,
                    Status = "Confirmed"
                };
                _repository.Add(reservation);
                return true;
            }
            return isAvaliable;
        }
        public List<DateTime> GetAvailableSlots(int doctorId, DateTime date)
        {
            List<DateTime> allSlots = _repository.GetSlotsForDay(doctorId, date);
            var reservedSlots = _repository.GetReservedSlots(doctorId, date);
            return allSlots.Except(reservedSlots).ToList();
        }

        public List<DateTime> GetNext14Days()
        {
            List<DateTime> days = new List<DateTime>();
            DateTime today = DateTime.Today;

            for (int i = 0; i < 14; i++)
            {
                days.Add(today.AddDays(i));
            }

            return days;
        }

        public void DeleteAllReservations()
        {
            _repository.DeleteAll();
        }



    }
}
