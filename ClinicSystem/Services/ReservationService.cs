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
        public readonly IReservationRepository _reservationRepository;
  
        public ReservationService(IReservationRepository repository)
        {
            _reservationRepository = repository;
        }

        public List<Reservation> GetAllReservations()
        {
            List<Reservation> reservations = _reservationRepository.GetAll();
            return reservations;
        }

        public Reservation GetReservationById(int id)
        {
            Reservation reservation = _reservationRepository.GetById(id);
            return reservation;
        }

        public bool AddReservation(Reservation reservation)
        {
            return _reservationRepository.Add(reservation);
        }

        public bool UpdateReservation(Reservation reservation)
        {
            return _reservationRepository.Update(reservation);
        }

        public bool DeleteReservation(int id)
        {
            return _reservationRepository.Delete(id);
        }

        public bool MakeReservation(string userId, int doctorId,int ClinicId , DateTime appointmentTime)
        {
            bool isAvaliable = _reservationRepository.IsAvaliable(doctorId, appointmentTime);
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
                _reservationRepository.Add(reservation);
                return true;
            }
            return isAvaliable;
        }
        public List<DateTime> GetAvailableSlots(int doctorId, DateTime date)
        {
            List<DateTime> allSlots = _reservationRepository.GetSlotsForDay(doctorId, date);
            var reservedSlots = _reservationRepository.GetReservedSlots(doctorId, date);
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

        public List<Reservation> GetReservationsForUser(string id)
        {
            return _reservationRepository.GetReservationsForUser(id);
        }

        public void DeleteAllReservations()
        {
            _reservationRepository.DeleteAll();
        }



    }
}
