using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBookById(int id);
        public Book AddBook(Book book);
        public Book UpdateBook(Book book);
        public Book DeleteBook(int id);

    }
}
