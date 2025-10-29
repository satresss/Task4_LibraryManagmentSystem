using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Название книги не может быть пустым.");

            return await _bookRepository.AddBookAsync(book);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Название книги не может быть пустым.");

            return await _bookRepository.UpdateBookAsync(book);
        }

        public async Task<Book?> DeleteBookAsync(int id)
        {
            return await _bookRepository.DeleteBookAsync(id);
        }
    }
}
