using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrarianController : ControllerBase
    {
        private readonly ILibrarianRepository _librarianRepository;
        public LibrarianController(ILibrarianRepository librarianRepository)
        {
            _librarianRepository = librarianRepository;
        }

        [HttpGet("OverDueBooks")]
        public async Task<ActionResult<IEnumerable<string>>> GetOverDueBooks()
        {
            return await _librarianRepository.GetAllOverDueBooks();
        }

        [HttpGet("GetAllBooks")]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            return await _librarianRepository.GetBooks();
        }

        [HttpPost("AddBook")]
        public async Task<ActionResult> AddBook(Book book)
        {
            var result = await _librarianRepository.AddBook(book);

            if(result)
                return Ok("Book added successfully");
            
            return Ok("Error adding book");
        }

        [HttpDelete("DeleteBook/{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            var result = await _librarianRepository.DeleteBookById(bookId);

            if(result)
                return Ok("Book deleted successfully");
            
            return Ok("Error deleting book");
        }
    }
}