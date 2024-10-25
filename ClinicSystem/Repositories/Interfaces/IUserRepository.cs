using ClinicSystem.Models;

namespace ClinicSystem.Repositories.Interfaces
{
    public interface IUserRepository
    {
        List<AppUser> GetAll();
        AppUser GetById(string id);
        bool Add(AppUser entity);
        bool Update(AppUser entity);
        bool Delete(string id);
    }
}
