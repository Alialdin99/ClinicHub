using ClinicSystem.Models;
using ClinicSystem.Repositories;
using ClinicSystem.Repositories.Interfaces;


namespace ClinicSystem.Services
{
    public class DoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository repository)
        {
            _doctorRepository = repository;
        }

        public List<Doctor> GetAllDoctors()
        {
            List<Doctor> doctors = _doctorRepository.GetAll();
            return doctors;
        }

        public Doctor GetDoctorById(int id)
        {
            Doctor doctor = _doctorRepository.GetById(id);
            return doctor;
        }

        public bool AddDoctor(Doctor doctor)
        {
            return _doctorRepository.Add(doctor);
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            return _doctorRepository.Update(doctor);
        }

        public bool DeleteDoctor(int id)
        {
            return _doctorRepository.Delete(id);
        }

        
    }
}
