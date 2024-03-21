using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Products> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("OracleConnection");
            optionsBuilder.UseOracle(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##EXAM3_12")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Amount).HasPrecision(10);

                entity.Property(e => e.CreatedAt).HasPrecision(7);

                entity.Property(e => e.ErrorCode).HasPrecision(10);
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("NUMBER(18,2)");

                entity.Property(e => e.RemainingAmount).HasPrecision(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
