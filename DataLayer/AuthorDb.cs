using BusinessLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class AuthorDb : IDb<Author, int>
    {
        private LibraryContext context;

        public AuthorDb(LibraryContext context)
        {
            this.context = context;
        }

        public void Create(Author item)
        {
            context.Authors.Add(item);
            context.SaveChanges();
        }

        public Author Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Authors.FirstOrDefault(a => a.Id == key);
        }

        public List<Author> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Authors.ToList();
        }

        public void Update(Author item, bool useNavigationalProperties = false)
        {
            context.Authors.Update(item);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            var author = context.Authors.Find(key);

            if (author != null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
        }
    }
}