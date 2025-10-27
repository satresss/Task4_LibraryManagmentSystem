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

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }

        public Book AddBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Название книги не может быть пустым.");

            return _bookRepository.AddBook(book);
        }

        public Book UpdateBook(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Название книги не может быть пустым.");

            var updated = _bookRepository.UpdateBook(book);
            return updated;
        }

        public Book DeleteBook(int id)
        {
            var deleted = _bookRepository.DeleteBook(id);
            return deleted;
        }
    }
}
