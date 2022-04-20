using CRUDApi.Models;

namespace CRUDApi.Repositories
{
    public class UserRepository
    {
        public static List<UserModel> Users = new()
        {
            new()
            {
                UserId = 1,
                Email = "Josh@email.com",
                Name = "Josh",
                Surname = "Adams",
                Role = "Administrator",
                Username = "joshua",
                Password = "zxcvbn1"
            },
            new()
            {
                UserId = 2,
                Email = "jtcnw@email.com",
                Name = "Steven",
                Surname = "Jacobson",
                Role = "Standard",
                Username = "steven123", Password = "zaq12wsx"
            }
        };
    }
}
