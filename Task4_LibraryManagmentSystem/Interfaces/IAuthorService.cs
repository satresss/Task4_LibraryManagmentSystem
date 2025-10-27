using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAllAuthors();
        public Author GetAuthorById(int id);
        public Author AddAuthor(Author author);
        public Author UpdateAuthor(Author author);
        public Author DeleteAuthor(int id);

    }
}
