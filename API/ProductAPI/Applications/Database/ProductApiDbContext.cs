using Microsoft.EntityFrameworkCore;
using ProductAPI.Applications.Database.EntitiesTypeConfigurations;
using ProductAPI.Applications.Entities;

namespace ProductAPI.Applications.Database
{
    public class ProductApiDbContext : DbContext
    {
        public ProductApiDbContext(DbContextOptions<ProductApiDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        }
    }
}
