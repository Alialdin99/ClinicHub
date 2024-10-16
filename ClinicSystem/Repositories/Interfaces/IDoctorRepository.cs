using ClinicSystem.Models;

namespace ClinicSystem.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAll();
        Doctor GetById(int id);
        bool Add(Doctor entity);
        bool Update(Doctor entity);
        bool Delete(int id);
    }
}
