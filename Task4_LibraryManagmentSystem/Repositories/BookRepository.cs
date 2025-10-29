using Microsoft.EntityFrameworkCore;
using Task4_LibraryManagmentSystem.Data;
using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> UpdateBookAsync(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook == null) return null;

            existingBook.Title = book.Title;
            existingBook.PublishedYear = book.PublishedYear;
            existingBook.AuthorId = book.AuthorId;

            await _context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<Book?> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return null;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return book;
        }
    }
}