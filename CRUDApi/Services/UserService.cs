using CRUDApi.Models;
using CRUDApi.Repositories;

namespace CRUDApi.Services
{
    public class UserService : IUserService
    {
        public UserModel Get(UserLogin userLogin)
        {
            UserModel user = UserRepository.Users.FirstOrDefault(x => x.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(userLogin.Password));

            return user;
        }
    }
}
