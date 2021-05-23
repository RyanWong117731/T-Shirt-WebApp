using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T_Shirt_WebApp.Models
{
    public class UserAccount
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
