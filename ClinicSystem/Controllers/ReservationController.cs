using ClinicSystem.Models;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ClinicSystem.Services.ClinicSystem.Services;
using Microsoft.AspNetCore.Authorization;

namespace ClinicSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly DoctorService _doctorService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ClinicService _clinicService;

        public ReservationController(ReservationService reservationService, DoctorService doctorService, UserManager<AppUser> userManager, ClinicService clinkService)
        {
            _reservationService = reservationService;
            _doctorService = doctorService;
            _userManager = userManager;
            _clinicService = clinkService;
        }

        [HttpGet]
        public IActionResult SelectDays(int doctorId)
        {
            var days = _reservationService.GetNext14Days();
            ViewBag.DoctorId = doctorId;
            return View(days);
        }
        
        [HttpGet]
        public IActionResult SelectTimeSlots(int doctorId, DateTime selectedDate)
        {
            var availableSlots = _reservationService.GetAvailableSlots(doctorId, selectedDate);
            ViewBag.DoctorId = doctorId;
            ViewBag.SelectedDate = selectedDate;
            return View(availableSlots);
        }
        [HttpPost]
        public async Task<IActionResult> MakeReservation(int doctorId, DateTime selectedSlot)
        {
            string currentUserId = _userManager.GetUserId(User);
            var doctor = _doctorService.GetDoctorById(doctorId);
            var clinic = _clinicService.GetClinicById(doctor.ClinicId);

            if (doctor == null)
                return NotFound();
            
            var reservation = new Reservation
            {
                UserId  = _userManager.GetUserId(User),
                User = _userManager.GetUserAsync(User).Result,
                //UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DoctorId = doctorId,
                Doctor = doctor,
                ClinicId = doctor.ClinicId,
                Clinic = clinic,
                AppointmentDate = selectedSlot,
                Status = "Pending"
            };

            var result = _reservationService.AddReservation(reservation);

            if (result)
                return RedirectToAction("Success");
            else
                return RedirectToAction("Error");
        }
        [HttpGet]
        public IActionResult GetReservationsForUser()
        {
            string currentUserId = _userManager.GetUserId(User);
            List<Reservation> reservations = _reservationService.GetReservationsForUser(currentUserId);
            return View(reservations);
        }
        [HttpGet]
        //public IActionResult GetReservationsForUser(string id)//to be for admin only per doctor
        //{

        //    List<Reservation> reservations = _reservationService.GetReservationsForUser(id);
        //    return View(reservations);
        //}

        [HttpGet]
        public IActionResult GetReservationDetails(int reservationId)
        {
            Reservation reservation = _reservationService.GetReservationById(reservationId);
            return View(reservation);
        }

        public IActionResult CancelReservation(int reservationId)
        {
           
            _reservationService.DeleteReservation(reservationId);
            return RedirectToAction("GetReservationsForUser");
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
