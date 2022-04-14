using CRUDApi.Models;

namespace CRUDApi.Repositories
{
    public class UserRepository
    {
        public static List<UserModel> Users = new()
        {
            new() { Username = "joshua", Password = "zxcvbn1", Email = "Josh@email.com", Name = "Josh", Surname = "Adams", Role = "Administrator" },
            new() { Username = "jtcnw", Password = "zaq12wsx", Email = "jtcnw@email.com", Name = "Steven", Surname = "Jacobson", Role = "Standard" }
        };
    }
}
