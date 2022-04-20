using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Models
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<UserModel> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<UserModel>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<UserModel>()
                .Property(u => u.Password)
                .IsRequired();
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
            optionsBuilder.UseSqlite("DefaultConnection");
        }
    }
}
