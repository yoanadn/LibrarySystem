using BusinessLayer;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class MemberDb : IDb<Member, int>
    {
        private LibraryContext context;

        public MemberDb(LibraryContext context)
        {
            this.context = context;
        }

        public void Create(Member item)
        {
            context.Members.Add(item);
            context.SaveChanges();
        }

        public Member Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Members.FirstOrDefault(m => m.Id == key);
        }

        public List<Member> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            return context.Members.ToList();
        }

        public void Update(Member item, bool useNavigationalProperties = false)
        {
            context.Members.Update(item);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            var member = context.Members.Find(key);

            if (member != null)
            {
                context.Members.Remove(member);
                context.SaveChanges();
            }
        }
    }
}