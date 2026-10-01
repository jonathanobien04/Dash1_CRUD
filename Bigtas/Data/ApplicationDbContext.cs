using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Crud_Bigtas.Models;

namespace Crud_Bigtas.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
