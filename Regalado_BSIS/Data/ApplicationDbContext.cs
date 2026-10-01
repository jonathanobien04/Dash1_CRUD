using FirstASP.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstASP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
