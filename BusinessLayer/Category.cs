using System.Collections.Generic;

namespace BusinessLayer
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookCategory> BookCategories { get; set; }
    }
}