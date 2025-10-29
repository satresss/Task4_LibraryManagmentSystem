using Microsoft.EntityFrameworkCore;
using Task4_LibraryManagmentSystem.Domain.Entities;

namespace Task4_LibraryManagmentSystem.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Author>().HasData(
                           new Author { Id = 1, Name = "Leo Tolstoy", DateOfBirth = new DateOnly(1828, 9, 9) },
                           new Author { Id = 2, Name = "Fyodor Dostoevsky", DateOfBirth = new DateOnly(1821, 11, 11) }
                       );

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "War and Peace", PublishedYear = 1869, AuthorId = 1 },
                new Book { Id = 2, Title = "Crime and Punishment", PublishedYear = 1866, AuthorId = 2 }
            );
        }
    }
}
