using Microsoft.EntityFrameworkCore;
using OrderAPI.Applications.Database.EntitiesTypeConfigurations;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Database
{
    public class OrderAPIDbContext : DbContext
    {
        public OrderAPIDbContext(DbContextOptions<OrderAPIDbContext> options) : base(options) { }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfigurations());
            modelBuilder.ApplyConfiguration(new OrderItemsEntityTypeConfigurations());
        }
    }
}
