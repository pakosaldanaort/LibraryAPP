
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface ILibrarianRepository
    {
        Task<List<Book>> GetAllOverDueBooks();
        Task<List<Book>> GetBooks();
        Task<bool> AddBook(Book book);
        Task<bool> DeleteBookById(int bookId);

    }
}
