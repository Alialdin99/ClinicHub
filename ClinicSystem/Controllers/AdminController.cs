using Microsoft.AspNetCore.Mvc;
using ClinicSystem.Models;
using ClinicSystem.Services;
using ClinicSystem.Services.ClinicSystem.Services;
using ClinicSystem.View_Models;
using Microsoft.AspNetCore.Authorization;

namespace ClinicSystem.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ClinicService _clinicService;
        private readonly DoctorService _doctorService;

        public AdminController(ClinicService clinicService, DoctorService doctorService)
        {
            _clinicService = clinicService;
            _doctorService = doctorService;
        }


        [HttpGet]
        public IActionResult AddClinic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddClinic(AddClinicViewModel model)
        {

            var clinic = new Clinic
            {
                Name = model.Name,
                ImagePath = model.ImagePath
            };
            _clinicService.AddClinic(clinic);
            return RedirectToAction("Index", "Home");

            return View(model);
        }

        [HttpGet]
        public IActionResult AddDoctor()
        {
            var model = new AddDoctorViewModel
            {
                Clinics = _clinicService.GetAllClinics()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddDoctor(AddDoctorViewModel model)
        {

            var doctor = new Doctor
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Title = model.Title,
                ImagePath = model.ImagePath,
                Salary = model.Salary,
                ExperienceYears = model.ExperienceYears,
                ClinicId = model.ClinicId
            };
            _doctorService.AddDoctor(doctor);
            return RedirectToAction("Index", "Home");

            model.Clinics = _clinicService.GetAllClinics();
            return View(model);
        }
    }
}
