using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckOutBook(int bookId, int userId)
        {
            var currentCheckedOutBooks = await _context.Books.Where(book => book.UserId == userId).ToListAsync();

            if(currentCheckedOutBooks.Count >= 3)
                return false;
            
            var overdueBooks = currentCheckedOutBooks.Where(book => book.OverDueDate < DateTime.Now).ToList();

            if(overdueBooks.Count > 0)
                return false;
            
            var book = await _context.Books.FindAsync(bookId);

            book.CheckOutDate = DateTime.Now;
            book.OverDueDate = DateTime.Now.AddDays(14);
            book.UserId = userId;

            var success = await _context.SaveChangesAsync() > 0;

            return success;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<List<Book>> ListBooksByUser(int userId)
        {
            return await _context.Books
                            .Where(book => book.UserId == userId).ToListAsync();

        }

        public async Task<bool> ReturnCheckedOutBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            book.CheckOutDate = null;
            book.OverDueDate = null;
            book.UserId = null;

            var success = await _context.SaveChangesAsync() > 0;

            return success;
        }

        public async Task<List<Book>> GetNoCheckedOutBooks()
        {
            return await _context.Books
                            .Where(book => !book.UserId.HasValue && !book.CheckOutDate.HasValue)
                            .ToListAsync();
        }
    }
}