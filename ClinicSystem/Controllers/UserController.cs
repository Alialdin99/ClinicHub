using ClinicSystem.Models;
using ClinicSystem.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class UserController:Controller
    {
        private readonly ReservationService _reservationService;
        private readonly UserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public UserController(ReservationService reservationService, UserService userService)
        {
            _reservationService = reservationService;
            _userService = userService;
        }

       

    }
}
