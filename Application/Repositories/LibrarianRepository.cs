using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly DataContext _context;
        public LibrarianRepository(DataContext context){
            _context = context;
        }
        public async Task<bool> AddBook(Book book)
        {
            _context.Books.Add(book);

            var success = await _context.SaveChangesAsync() > 0;

            return success;

        }

        public async Task<bool> DeleteBookById(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            _context.Remove(book);

            var success = await _context.SaveChangesAsync() > 0;

            return success;
        }

        public async Task<List<string>> GetAllOverDueBooks()
        {
            return await _context.Books
                    .Where(x => x.OverDueDate < DateTime.Today)
                    .Select(x => "Title: " + x.Title + ", Author: " + x.Author + ", ISBN: " + x.ISBN )
                    .ToListAsync();
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _context.Books.ToListAsync();
        }
    }
}