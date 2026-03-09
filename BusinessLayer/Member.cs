using System.Collections.Generic;

namespace BusinessLayer
{
    public class Member
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<Loan> Loans { get; set; }
    }
}