using Microsoft.EntityFrameworkCore;
using OrderAPI.Applications.Database.EntitiesTypeConfigurations;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Database
{
    public class ExamDbContext : DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }
        public DbSet<Products> Products { get; set; }
        public DbSet<Orders> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
        }
    }
}
