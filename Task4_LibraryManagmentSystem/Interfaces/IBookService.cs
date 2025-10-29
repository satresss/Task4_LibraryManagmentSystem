using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Interfaces
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBooksAsync();
        public Task<Book?> GetBookByIdAsync(int id);
        public Task<Book> AddBookAsync(Book book);
        public Task<Book> UpdateBookAsync(Book book);
        public Task<Book?> DeleteBookAsync(int id);

    }
}
