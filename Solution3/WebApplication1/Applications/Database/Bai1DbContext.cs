using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database.EntityTypeConfigurations;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database
{
    public class Bai1DbContext : DbContext
    {
        public Bai1DbContext(DbContextOptions<Bai1DbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<TradeMark> TradeMarks { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new StatusEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new TradeMarkEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new SupplierEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new OrderDetailEntityTypeConfigurations());
        }

    }
}
