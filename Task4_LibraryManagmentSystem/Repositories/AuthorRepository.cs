using Task4_LibraryManagmentSystem.Interfaces;
using Task4_LibraryManagmentSystem.Models;

namespace Task4_LibraryManagmentSystem.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private List<Author> _authorsList;
        public AuthorRepository(List<Author> authors) 
        { 
            _authorsList = authors;
        }

        public List<Author> GetAll() 
        { 
            return _authorsList;
        }

        public Author GetAuthorById(int Id) 
        {
            foreach (Author author in _authorsList) 
            {
                if (author.Id == Id) 
                { 
                    return author;
                }
            }
            return null;
        }

        public Author AddAuthor(Author author) 
        { 
           _authorsList.Add(author);
            return author;
        }

        public Author UpdateAuthor(Author author) 
        {
            for (int i = 0; i < _authorsList.Count; i++) 
            {
                if (_authorsList[i].Id == author.Id) 
                { 
                    _authorsList[i] = author;
                    return author;
                }
            }
            return null;
        }

        public Author DeleteAuthor(int id)
        {
            var author = _authorsList.Find(a => a.Id == id);
            if (author != null)
            {
                _authorsList.Remove(author);
            }
            return author;
        }

    }
}