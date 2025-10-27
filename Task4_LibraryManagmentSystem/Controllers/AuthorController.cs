using Microsoft.AspNetCore.Mvc;
using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;
using Task4_LibraryManagmentSystem.Services;

namespace Task4_LibraryManagmentSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var authors = _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Author author = _authorService.GetAuthorById(id);
            return author == null ? NotFound("Автор не найден") : Ok(author);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Author author)
        {
            try
            {
                Author added = _authorService.AddAuthor(author);
                return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Author author)
        {
            if (id != author.Id)
                return BadRequest("ID не совпадает");

            try
            {
                Author updated = _authorService.UpdateAuthor(author);
                return updated == null ? NotFound("Автор не найден") : Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Author deleted = _authorService.DeleteAuthor(id);
            return deleted == null ? NotFound("Автор не найден") : NoContent();
        }
    }
}
