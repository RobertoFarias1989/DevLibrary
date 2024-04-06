using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLibrary.Core.Entities
{
    public class User : BaseEntity
    {
        public User(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;            
            Password = password;
            Role = role;

            CreatedAt = DateTime.Now;
            Active = true;
            Loans = new List<Loan>();
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public string Password { get; private set; }
        public string Role { get; private set; }
        public List<Loan> Loans { get; private set; }
    }
}
