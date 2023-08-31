using Microsoft.EntityFrameworkCore;

namespace apiDeneme.Models.DataContext
{
    public class DbContextErnet : DbContext
    {
        public DbContextErnet(DbContextOptions<DbContextErnet>options) : base(options) 
        { 

        }

        public DbSet<Works> Works { get; set; }
        public DbSet<Sofor> Sofors { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
    }
}
