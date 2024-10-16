using ClinicSystem.Models;
using Microsoft.EntityFrameworkCore;
using ClinicSystem.DataContext;
using ClinicSystem.Repositories.Interfaces;

namespace ClinicSystem.Repositories
{
    public class ClinicRepository:IClinicRepository
    {
        private readonly AppDbContext _dbContext;

        public ClinicRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Clinic> GetAll()
        {
           List<Clinic> clinics = _dbContext.Clinics.ToList();
           return clinics;
        }

        public Clinic GetById(int id)
        {
            Clinic clinic = _dbContext.Clinics.Include(c=>c.Doctors).FirstOrDefault(c => c.Id == id);
            return clinic;
        }

        public bool Add(Clinic entity)
        {
            _dbContext.Clinics.Add(entity);
            return _dbContext.SaveChanges()>0;
        }

        public bool Update(Clinic entity)
        {
            _dbContext.Clinics.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Clinic clinic = _dbContext.Clinics.FirstOrDefault(c => c.Id == id);
            _dbContext.Remove(clinic);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
