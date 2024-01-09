using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database.EntityTypeConfigurations;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database
{
    public class Bai2DbContext : DbContext
    {
        public Bai2DbContext(DbContextOptions<Bai2DbContext> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<BasketItems> BasketItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new OrderItemEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new BasketItemsEntityTypeConfigurations());
        }

    }
}
