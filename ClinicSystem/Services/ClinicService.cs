using ClinicSystem.Models;
using ClinicSystem.Repositories;
using ClinicSystem.Repositories.Interfaces;

namespace ClinicSystem.Services
{
    
    namespace ClinicSystem.Services
    {
        public class ClinicService
        {
            private readonly IClinicRepository _repository;

            public ClinicService(IClinicRepository repository)
            {
                _repository = repository;
            }

            public List<Clinic> GetAll()
            {
                List<Clinic> clinics = _repository.GetAll();
                return clinics;
            }

            public Clinic GetById(int id)
            {
                Clinic clinic = _repository.GetById(id);
                return clinic;
            }

            public bool Add(Clinic clinic)
            {
                return _repository.Add(clinic);
            }

            public bool Update(Clinic clinic)
            {
                return _repository.Update(clinic);
            }

            public bool Delete(int id)
            {
                return _repository.Delete(id);
            }
        }
    }

}
