using Microsoft.AspNetCore.Mvc;
using Task4_LibraryManagmentSystem.Domain.Entities;
using Task4_LibraryManagmentSystem.Domain.Interfaces;
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
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);
            return author == null ? NotFound("Автор не найден") : Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            try
            {
                var added = await _authorService.AddAuthorAsync(author);
                return CreatedAtAction(nameof(GetById), new { id = added.Id }, added);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Author author)
        {
            if (id != author.Id)
                return BadRequest("ID не совпадает");

            try
            {
                var updated = await _authorService.UpdateAuthorAsync(author);
                return updated == null ? NotFound("Автор не найден") : Ok(updated);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _authorService.DeleteAuthorAsync(id);
            return deleted == null ? NotFound("Автор не найден") : NoContent();
        }
    }
}
