using ClinicSystem.Models;
using ClinicSystem.Services.ClinicSystem.Services;

using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.Controllers
{
    public class ClinicController:Controller
    {
        private readonly ClinicService _clinicService;

        public ClinicController(ILogger<ClinicController> logger, ClinicService clinicService)
        {
            _clinicService = clinicService;
        }
        public IActionResult ClinicDetails(int id)
        {
            Clinic clinic = _clinicService.GetClinicById(id);
            if (clinic == null)
            {
                return NotFound();
            }
            return View(clinic);
        }
    }
}
