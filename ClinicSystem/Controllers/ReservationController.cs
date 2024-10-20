using ClinicSystem.Models;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ClinicSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;
        private readonly DoctorService _doctorService;
        private readonly UserManager<AppUser> _userManager;

        public ReservationController(ReservationService reservationService, DoctorService doctorService, UserManager<AppUser> userManager)
        {
            _reservationService = reservationService;
            _doctorService = doctorService;
            _userManager = userManager;
        }
        
        public IActionResult SelectDays(int doctorId)
        {
            var days = _reservationService.GetNext14Days();
            ViewBag.DoctorId = doctorId;
            return View(days);
        }
        
        public IActionResult SelectTimeSlots(int doctorId, DateTime selectedDate)
        {
            var availableSlots = _reservationService.GetAvailableSlots(doctorId, selectedDate);
            ViewBag.DoctorId = doctorId;
            ViewBag.SelectedDate = selectedDate;
            return View(availableSlots);
        }
        [HttpPost]
        public IActionResult MakeReservation(int doctorId, DateTime selectedSlot)
        {
            string currentUserId = _userManager.GetUserId(User);


            var doctor = _doctorService.GetById(doctorId);
            if (doctor == null)
                return NotFound();
            

            var reservation = new Reservation
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DoctorId = doctorId,
                ClinicId = doctor.ClinicId,
                AppointmentDate = selectedSlot,
                Status = "Pending"
            };

            var result = _reservationService.Add(reservation);

            if (result)
                return RedirectToAction("Success");
            else
                return RedirectToAction("Error");
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
