using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Models

{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Name)
                .IsRequired();

            modelBuilder.Entity<UserLogin>()
                .Property(u => u.Username)
                .IsRequired();

            modelBuilder.Entity<UserLogin>()
                .Property(u => u.Password)
                .IsRequired();

            modelBuilder.Entity<UserLogin>()
                .HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
            optionsBuilder.UseSqlite("DefaultConnection");
        }
    }
}
