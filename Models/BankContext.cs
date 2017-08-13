using Microsoft.EntityFrameworkCore;

namespace bankaccounts.Models
{
    public class BankContext: DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options) { }

        public DbSet<User> user {get;set;}

        public DbSet<Transaction> transaction {get; set;}
    }

}