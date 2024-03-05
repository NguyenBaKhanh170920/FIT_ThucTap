using BasketAPI.Applications.Database.EntitiesTypeConfigurations;
using BasketAPI.Applications.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasketAPI.Applications.Database
{
    public class BasketAPIDbContext : DbContext
    {
        public BasketAPIDbContext(DbContextOptions<BasketAPIDbContext> options) : base(options) { }
        public DbSet<BasketItems> BasketItems { get; set; }
        public DbSet<Baskets> Baskets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BasketEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BasketItemsEntityTypeConfiguration());
        }
    }
}
