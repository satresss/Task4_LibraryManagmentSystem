using Microsoft.AspNetCore.Mvc;
using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;
using Task4_LibraryManagmentSystem.Services;

namespace Task4_LibraryManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Book book = _bookService.GetBookById(id);
            return book == null ? NotFound("Книга не найдена") : Ok(book);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            try
            {
                Book added = _bookService.AddBook(book);
                return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest("ID не совпадает");

            try
            {
                Book updated = _bookService.UpdateBook(book);
                return updated == null ? NotFound("Книга не найдена") : Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Book deleted = _bookService.DeleteBook(id);
            return deleted == null ? NotFound("Книга не найдена") : NoContent();
        }
    }
}
