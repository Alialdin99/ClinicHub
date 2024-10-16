using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ClinicSystem.Models;
using ClinicSystem.Services;
using ClinicSystem.Services.ClinicSystem.Services;

namespace ClinicSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClinicService _clinicService;
        private readonly DoctorService _doctorService;

        public HomeController(ILogger<HomeController> logger,ClinicService clinicService, DoctorService doctorService)
        {
            _logger = logger;
            _clinicService = clinicService;
            _doctorService = doctorService;
        }

        public IActionResult Index()
        {
            List<Clinic> clinics = _clinicService.GetAll();
            return View(clinics);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}