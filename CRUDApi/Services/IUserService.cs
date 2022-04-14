using CRUDApi.Models;

namespace CRUDApi.Services
{
    public interface IUserService
    {
        public UserModel Get(UserLogin userLogin);
    }
}
