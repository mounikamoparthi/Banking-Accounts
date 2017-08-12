using System;
using System.Collections.Generic;

namespace bankaccounts.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public double CurrentBal { get; set;}
        public List<Transaction> Transactions { get; set; }
 
        public User()
        {
            Transactions = new List<Transaction>();
            CurrentBal = 0;
        }
    }
}
    