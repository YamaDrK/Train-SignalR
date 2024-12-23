using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Product> Product { get; set; } = null!;
    }
}
