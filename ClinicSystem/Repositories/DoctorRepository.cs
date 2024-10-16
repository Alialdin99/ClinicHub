using ClinicSystem.Models;
using ClinicSystem.DataContext;
using ClinicSystem.Repositories.Interfaces;

namespace ClinicSystem.Repositories
{
    public class DoctorRepository:IDoctorRepository
    {
        private readonly AppDbContext _dbContext;

        public DoctorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctor = _dbContext.Doctors.ToList();
            return doctor;
        }
        public Doctor GetById(int id)
        {
            Doctor doctor = _dbContext.Doctors.FirstOrDefault(c => c.Id == id);
            return doctor;
        }
        public bool Add(Doctor entity)
        {
            _dbContext.Doctors.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(Doctor entity)
        {
            _dbContext.Doctors.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Doctor doctor = _dbContext.Doctors.FirstOrDefault(d => d.Id == id);
            _dbContext.Remove(doctor);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
