using CRUDApi.Models;
using System.Security.Claims;

namespace CRUDApi.Services
{
    public interface IBookService
    {
        public Book Create(Book book);
        public Book Get(int id);
        public List<Book> List();
        public Book Update(Book book);
        public bool Delete(int id);
    }
}
