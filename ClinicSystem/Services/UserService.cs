using ClinicSystem.Models;
using ClinicSystem.Repositories.Interfaces;

namespace ClinicSystem.Services
{
    public class UserService
    {
        public readonly IUserRepository _userRepository;
        public readonly IReservationRepository _reservationRepository;

        public UserService(IUserRepository userRepository, IReservationRepository reservationRepository)
        {
            _userRepository = userRepository;
            _reservationRepository = reservationRepository;
        }

        public List<AppUser> GetAllUsers()
        {
            List<AppUser> users = _userRepository.GetAll();
            return users;
        }

        public AppUser GetUserById(string id)
        {
            AppUser user = _userRepository.GetById(id);
            return user;
        }

        public bool AddUser(AppUser user)
        {
            return _userRepository.Add(user);
        }

        public bool UpdateUser(AppUser user)
        {
            return _userRepository.Update(user);
        }

        public bool DeleteUser(string id)
        {
            return _userRepository.Delete(id);
        }

    }
}
