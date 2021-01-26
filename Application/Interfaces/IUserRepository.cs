using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace Application
{
    public interface IUserRepository
    {
         Task<bool> CheckOutBook(int bookId, int userId);
         Task<bool> ReturnCheckedOutBook(int bookId);
         Task<List<Book>> ListBooksByUser(int userId);
         Task<List<User>> GetUsers();
         Task<List<Book>> GetNoCheckedOutBooks();
    }
}