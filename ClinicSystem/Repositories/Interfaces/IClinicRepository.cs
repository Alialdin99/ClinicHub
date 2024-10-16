using ClinicSystem.Models;

namespace ClinicSystem.Repositories.Interfaces
{
    public interface IClinicRepository
    {
        List<Clinic> GetAll();
        Clinic GetById(int id);
        bool Add(Clinic entity);
        bool Update(Clinic entity);
        bool Delete(int id);
    }
}
