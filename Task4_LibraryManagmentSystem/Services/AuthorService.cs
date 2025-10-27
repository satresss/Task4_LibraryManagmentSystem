using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return _authorRepository.GetAuthorById(id);
        }

        public Author AddAuthor(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Имя автора не может быть пустым.");

            return _authorRepository.AddAuthor(author);
        }

        public Author UpdateAuthor(Author author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Имя автора не может быть пустым.");

            return _authorRepository.UpdateAuthor(author);
        }

        public Author DeleteAuthor(int id)
        {
            return _authorRepository.DeleteAuthor(id);
        }
    }
}
