using BusinessLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class CategoryDb : IDb<Category, int>
    {
        private LibraryContext context;

        public CategoryDb(LibraryContext context)
        {
            this.context = context;
        }

        public void Create(Category item)
        {
            context.Categories.Add(item);
            context.SaveChanges();
        }

        public Category Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Categories.FirstOrDefault(c => c.Id == key);
        }

        public List<Category> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Categories.ToList();
        }

        public void Update(Category item, bool useNavigationalProperties = false)
        {
            context.Categories.Update(item);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            var category = context.Categories.Find(key);

            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}