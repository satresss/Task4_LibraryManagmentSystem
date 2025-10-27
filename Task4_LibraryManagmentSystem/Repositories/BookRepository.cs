using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private List<Book> _booksList;
        public BookRepository(List<Book> books)
        {
            _booksList = books;
        }
        public List<Book> GetAll()
        {
            return _booksList;
        }
        public Book GetBookById(int id)
        {
            foreach (Book book in _booksList)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }
        public Book AddBook(Book book)
        {
            _booksList.Add(book);
            return book;
        }
        public Book UpdateBook(Book book)
        {
            for (int i = 0; i < _booksList.Count; i++)
            {
                if (_booksList[i].Id == book.Id)
                {
                    _booksList[i] = book;
                    return book;
                }
            }
            return null;
        }
        public Book DeleteBook(int id)
        {
            var book = _booksList.Find(b => b.Id == id);
            if (book != null)
            {
                _booksList.Remove(book);
            }
            return book;
        }
    }
}