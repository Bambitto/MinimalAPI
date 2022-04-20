using CRUDApi.Models;
using CRUDApi.Repositories;
using System.Security.Claims;

namespace CRUDApi.Services
{
    public class BookService : IBookService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        
        public BookService(IHttpContextAccessor httpContextAccessor)
        {
            _contextAccessor = httpContextAccessor;
        }
        public Book Create(Book book)
        {
            var username = _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            book.Username = username;
            book.Id = book.Id + 1;
            BookRepository.Books.Add(book);
            return book;
        }

        public bool Delete(int id)
        {
            var oldBook = BookRepository.Books.FirstOrDefault(x => x.Id == id);
            if (oldBook == null) { return false; }
            BookRepository.Books.Remove(oldBook);
            return true;
        }

        public Book Get(int id)
        {
            var result = BookRepository.Books.FirstOrDefault(x => x.Id == id);
            if (result == null) { return null; }
            return result;
        }

        public List<Book> List()
        {
            var books = BookRepository.Books;
            return books;
        }

        public Book Update(Book book)
        {
            var outdatedBook = BookRepository.Books.FirstOrDefault(x => x.Id == book.Id);
            if (outdatedBook == null) { return null; }

            outdatedBook.Name = book.Name;
            outdatedBook.Author = book.Author;
            outdatedBook.Description = book.Description;

            return book;
        }
    }
}
