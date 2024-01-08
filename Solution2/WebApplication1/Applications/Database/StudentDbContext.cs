using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Database.EntityTypeConfigurations;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
        }
    }
}
