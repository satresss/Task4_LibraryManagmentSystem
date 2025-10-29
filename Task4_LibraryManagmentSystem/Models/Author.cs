﻿namespace Task4_LibraryManagmentSystem.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
