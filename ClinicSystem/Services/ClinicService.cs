using ClinicSystem.Models;
using ClinicSystem.Repositories;
using ClinicSystem.Repositories.Interfaces;

namespace ClinicSystem.Services
{
    
    namespace ClinicSystem.Services
    {
        public class ClinicService
        {
            private readonly IClinicRepository _clinicRepository;

            public ClinicService(IClinicRepository repository)
            {
                _clinicRepository = repository;
            }

            public List<Clinic> GetAllClinics()
            {
                List<Clinic> clinics = _clinicRepository.GetAll();
                return clinics;
            }

            public Clinic GetClinicById(int id)
            {
                Clinic clinic = _clinicRepository.GetById(id);
                return clinic;
            }

            public bool AddClinic(Clinic clinic)
            {
                return _clinicRepository.Add(clinic);
            }

            public bool UpdateClinic(Clinic clinic)
            {
                return _clinicRepository.Update(clinic);
            }

            public bool DeleteClinic(int id)
            {
                return _clinicRepository.Delete(id);
            }
        }
    }

}
