using ClinicSystem.Models;
using ClinicSystem.Repositories;
using ClinicSystem.Repositories.Interfaces;


namespace ClinicSystem.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = _repository.GetAll();
            return doctors;
        }

        public Doctor GetById(int id)
        {
            Doctor doctor = _repository.GetById(id);
            return doctor;
        }

        public bool Add(Doctor doctor)
        {
            return _repository.Add(doctor);
        }

        public bool Update(Doctor doctor)
        {
            return _repository.Update(doctor);
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        
    }
}
