using Microsoft.EntityFrameworkCore;
using Task4_LibraryManagmentSystem.Data;
using Task4_LibraryManagmentSystem.Domain.Entities;
using Task4_LibraryManagmentSystem.Domain.Interfaces;

namespace Task4_LibraryManagmentSystem.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private LibraryContext _context;

        public AuthorRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors
                .Include(a => a.Books)
                .ToListAsync();
        }

        public async Task<Author?> GetAuthorByIdAsync(int id)
        {
            return await _context.Authors
                .Include(a => a.Books)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author?> UpdateAuthorAsync(Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(author.Id);
            if (existingAuthor == null) return null;

            existingAuthor.Name = author.Name;
            existingAuthor.DateOfBirth = author.DateOfBirth;

            await _context.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task<Author?> DeleteAuthorAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null) return null;

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }

    }
}