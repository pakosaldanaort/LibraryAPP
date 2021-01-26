using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasData(
                    new User { UserId = 1, FirstName = "User 1", LastName = "Librarian", Email = "user1@gmail.com", Password = "12345", IsLibrerian = true},
                    new User { UserId = 2, FirstName = "User 2", LastName = "NormalUser", Email = "user2@gmail.com", Password = "12345", IsLibrerian = false},
                    new User { UserId = 3, FirstName = "User 3", LastName = "NormalUser", Email = "user3@gmail.com", Password = "12345", IsLibrerian = false},
                    new User { UserId = 4, FirstName = "User 4", LastName = "NormalUser", Email = "user4@gmail.com", Password = "12345", IsLibrerian = false}
                );
            
            builder.Entity<Book>()
                .HasData(
                    new Book { BookId = 1, Title = "Book 1", Author = "Book 1 Author", ISBN = "123456789"},
                    new Book { BookId = 2, Title = "Book 2", Author = "Book 2 Author", ISBN = "987654321"},
                    new Book { BookId = 3, Title = "Book 3", Author = "Book 3 Author", ISBN = "345692817"},
                    new Book { BookId = 4, Title = "Book 4", Author = "Book 4 Author", ISBN = "248728749"}
                );
        }
        
    }
}