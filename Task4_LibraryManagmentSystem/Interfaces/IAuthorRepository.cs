using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Interfaces
{
    public interface IAuthorRepository
    {
        public List<Author> GetAll();
        public Author GetAuthorById(int Id);
        public Author AddAuthor(Author author);
        public Author UpdateAuthor(Author author);
        public Author DeleteAuthor(int Id);

    }
}
