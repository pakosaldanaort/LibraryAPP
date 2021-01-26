using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("ListBooks/{userId}")]
        public async Task<ActionResult<List<Book>>> GetBooksByUser(int userId)
        {
            return await _userRepository.ListBooksByUser(userId);
        }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        [HttpGet("GetNoCheckedOutBooks")]
        public async Task<ActionResult<List<Book>>> GetNoCheckedOutBooks()
        {
            return await _userRepository.GetNoCheckedOutBooks();
        }

        [HttpPut("CheckOutBook/{userId}/{bookId}")]
        public async Task<ActionResult> CheckOutBook(int userId, int bookId)
        {
            var result = await _userRepository.CheckOutBook(bookId, userId);

            if(result)
                return Ok("Book checked-out successfully");

            return Ok("You can't check-out this book");
        
        }

        [HttpPut("ReturnBook/{bookId}")]
        public async Task<ActionResult> ReturnCheckedOutBook(int bookId)
        {
            var result = await _userRepository.ReturnCheckedOutBook(bookId);

            if(result)
                return Ok("Book returned successfully");

            return Ok("Error returning book");
        }



    }
}