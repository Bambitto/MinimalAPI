using CRUDApi.Models;

namespace CRUDApi.Repositories
{
    public class BookRepository
    {
        public static List<Book> Books = new()
        {
            new() { Id = 1, Name = "Harry Potter", Description = "Harry Potter Chamber of Secrets", Author = "J.K. Rowling" },
            new() { Id = 2, Name = "In Search of Lost Time", Description = "Swann's Way, the first part of A la recherche de temps perdu.", Author = "Marcel Proust" },
            new() { Id = 3, Name = "Ulysses", Description = "Ulysses chronicles the passage of Leopold Bloom through Dublin during and ordinary day.", Author= "James Joyce" }
        };
    }
}
