using CRUDApi.Models;

namespace CRUDApi.Repositories
{
    public class UserRepository
    {
        public static List<UserModel> Users = new()
        {
            new()
            {
                Id = 1,
                Email = "Josh@email.com",
                Name = "Josh",
                Surname = "Adams",
                Role = "Administrator",
                UserLogin = new UserLogin()
                {
                  Username = "joshua", Password = "zxcvbn1"
                }
            },
            new()
            {
                Id = 2,
                Email = "jtcnw@email.com",
                Name = "Steven",
                Surname = "Jacobson",
                Role = "Standard",
                UserLogin = new UserLogin()
                {
                Username = "steven123", Password = "zaq12wsx"
                }
            }
        };
    }
}
