using CRUDApi.Models;
using CRUDApi.Repositories;

namespace CRUDApi.Services
{
    public class UserService : IUserService
    {
        public UserModel Get(UserModel userModel)
        {
            UserModel user = UserRepository.Users.FirstOrDefault(x => x.Username.Equals(userModel.Username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(userModel.Password));

            return user;
        }
    }
}
