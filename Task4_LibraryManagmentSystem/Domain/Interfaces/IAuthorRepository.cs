using Task4_LibraryManagmentSystem.Domain.Entities;

namespace Task4_LibraryManagmentSystem.Domain.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAllAsync();
        public Task<Author?> GetAuthorByIdAsync(int id);
        public Task<Author> AddAuthorAsync(Author author);
        public Task<Author?> UpdateAuthorAsync(Author author);
        public Task<Author?> DeleteAuthorAsync(int id);

    }
}
