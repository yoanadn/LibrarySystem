using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class LoanDb : IDb<Loan, int>
    {
        private LibraryContext context;

        public LoanDb(LibraryContext context)
        {
            this.context = context;
        }

        public void Create(Loan item)
        {
            context.Loans.Add(item);
            context.SaveChanges();
        }

        public Loan Read(int key, bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Loan> query = context.Loans;

            if (useNavigationalProperties)
            {
                query = query.Include(l => l.Book)
                           .Include(l => l.Member);
            }

            return query.FirstOrDefault(l => l.Id == key);
        }

        public List<Loan> ReadAll(bool useNavigationalProperties = false, bool isReadOnly = false)
        {
            IQueryable<Loan> query = context.Loans;

            if (useNavigationalProperties)
            {
                query = query.Include(l => l.Book)
                           .Include(l => l.Member);
            }

            return query.ToList();
        }

        public void Update(Loan item, bool useNavigationalProperties = false)
        {
            context.Loans.Update(item);
            context.SaveChanges();
        }

        public void Delete(int key)
        {
            var loan = context.Loans.Find(key);

            if (loan != null)
            {
                context.Loans.Remove(loan);
                context.SaveChanges();
            }
        }
    }
}