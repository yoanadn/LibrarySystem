using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class BookDb : IDb<Book, int>
    {
        private LibraryContext context;

        public BookDb(LibraryContext context)
        {
            this.context = context;
        }

        public void Create(Book item)
        {
            context.Books.Add(item);
            context.SaveChanges();
        }

        public Book Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Book> query = context.Books;

            if (useNavigationalProperties)
            {
                query = query.Include(b => b.Author)
                           .Include(b => b.BookCategories);
            }

            return query.FirstOrDefault(b => b.Id == key);
        }

        public List<Book> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Book> query = context.Books;

            if (useNavigationalProperties)
            {
                query = query.Include(b => b.Author)
                           .Include(b => b.BookCategories);
            }

            return query.ToList();
        }

        public void Update(Book item, bool useNavigationalProperties = false)
        {
            context.Books.Update(item);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            var book = context.Books.Find(key);

            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
        }
    }
}