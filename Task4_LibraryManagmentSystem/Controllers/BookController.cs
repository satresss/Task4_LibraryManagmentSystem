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
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return book == null ? NotFound("Книга не найдена") : Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Book book)
        {
            try
            {
                var added = await _bookService.AddBookAsync(book);
                return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Book book)
        {
            if (id != book.Id)
                return BadRequest("ID не совпадает");

            try
            {
                var updated = await _bookService.UpdateBookAsync(book);
                return updated == null ? NotFound("Книга не найдена") : Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _bookService.DeleteBookAsync(id);
            return deleted == null ? NotFound("Книга не найдена") : NoContent();
        }
    }
}
