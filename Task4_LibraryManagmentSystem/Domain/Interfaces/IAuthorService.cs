using Task4_LibraryManagmentSystem.Domain.Entities;

namespace Task4_LibraryManagmentSystem.Domain.Interfaces
{
    public interface IAuthorService
    {
        public Task<List<Author>> GetAllAuthorsAsync();
        public Task<Author?> GetAuthorByIdAsync(int id);
        public Task<Author> AddAuthorAsync(Author author);
        public Task<Author> UpdateAuthorAsync(Author author);
        public Task<Author?> DeleteAuthorAsync(int id);

    }
}
