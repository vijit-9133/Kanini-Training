using Microsoft.EntityFrameworkCore;
using CodeFirstApp.Models;

namespace CodeFirstApp.Models
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext(DbContextOptions<ProductDBContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<CodeFirstApp.Models.Categories> Categories { get; set; } = default!;
    }
}