using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLG_Interview.Models;
using MLG_Interview.Repository;

namespace MLG_Interview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public readonly BookRepositoryInterface bookRepository;
        public BookController(BookRepositoryInterface bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = bookRepository.GetAllBooks();
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetBookById(int id)
        {
            var book = bookRepository.GetBookByID(id);
            if (book == null)
            {
                return NotFound(id);
            }
            return Ok(book);
        }
        [HttpPost]
        public IActionResult InsertBook(Book book)
        {
            bookRepository.InsertBook(book);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            bookRepository.UpdateBook(id, book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            bookRepository.DeleteBook(id);
            return NoContent();
        }

    }
}
