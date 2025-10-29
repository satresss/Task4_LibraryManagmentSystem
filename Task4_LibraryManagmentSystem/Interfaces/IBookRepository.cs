using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllAsync();
        public Task<Book?> GetBookByIdAsync(int id);
        public Task<Book> AddBookAsync(Book book);
        public Task<Book?> UpdateBookAsync(Book book);
        public Task<Book?> DeleteBookAsync(int id);

    }
}
