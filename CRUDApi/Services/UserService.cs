using CRUDApi.Models;

namespace CRUDApi.Services
{
    public class UserService : IUserService
    {
        public User Get(BooksDbContext context, string username, string password)
        {
            User user = context.Users.Where(x => x.Username == username && x.Password == password).FirstOrDefault();
            //FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password, StringComparison.OrdinalIgnoreCase));
            return user;
        }
    }
}
