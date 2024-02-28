using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database.EntityTypeConfigurations;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database
{
    public class Bai4DbContext : DbContext
    {
        public Bai4DbContext(DbContextOptions<Bai4DbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }
        public DbSet<Baskets> Baskets { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BasketEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
        }
    }
}
