using CRUDApi.Models;
using CRUDApi.Repositories;

namespace CRUDApi.Services
{
    public class UserService : IUserService
    {
        public UserModel Get(UserLogin userLogin)
        {
            UserModel user = UserRepository.Users.FirstOrDefault(x => x.UserLogin.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && x.UserLogin.Password.Equals(userLogin.Password));

            return user;
        }
    }
}
