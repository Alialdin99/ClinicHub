using ClinicSystem.Models;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }
        public IActionResult Index()
        {
            List<Reservation> reservations = _reservationService.GetAll();
            return View(reservations);
        }

    }
}
