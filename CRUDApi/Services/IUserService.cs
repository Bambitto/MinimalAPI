using CRUDApi.Models;

namespace CRUDApi.Services
{
    public interface IUserService
    {
        public User Get(BooksDbContext context, string username, string password);
    }
}
