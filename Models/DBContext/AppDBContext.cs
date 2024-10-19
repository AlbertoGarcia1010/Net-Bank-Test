using Microsoft.EntityFrameworkCore;
using AppBank.Models.Entities;

namespace AppBank.Models.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<CashType> CashTypes { get; set; }
    }
}
