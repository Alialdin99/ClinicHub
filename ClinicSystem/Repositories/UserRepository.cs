using ClinicSystem.DataContext;
using ClinicSystem.Models;
using ClinicSystem.Repositories.Interfaces;

namespace ClinicSystem.Repositories
{
    public class UserRepository:IUserRepository
    {
        public readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AppUser> GetAll()
        {
            List<AppUser> users = _dbContext.Users.ToList();
            return users;
        }

        public AppUser GetById(string id)
        {
            AppUser user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public bool Add(AppUser entity)
        {
            _dbContext.Users.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Update(AppUser entity)
        {
            _dbContext.Users.Update(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(string id)
        {
            AppUser user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
            _dbContext.Remove(user);
            return _dbContext.SaveChanges() > 0;
        }
        
    }
}
