using System.Collections.Generic;

namespace BusinessLayer
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}