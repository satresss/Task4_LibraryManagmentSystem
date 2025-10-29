using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetAuthorByIdAsync(id);
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Имя автора не может быть пустым.");

            return await _authorRepository.AddAuthorAsync(author);
        }

        public async Task<Author> UpdateAuthorAsync(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Имя автора не может быть пустым.");

            return await _authorRepository.UpdateAuthorAsync(author);
        }

        public async Task<Author?> DeleteAuthorAsync(int id)
        {
            return await _authorRepository.DeleteAuthorAsync(id);
        }
    }
}
