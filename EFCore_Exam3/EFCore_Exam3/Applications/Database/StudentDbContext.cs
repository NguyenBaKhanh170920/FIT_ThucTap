using EFCore_Exa2.Applications.Database.EntityTypeConfigurations;
using EFCore_Exa2.Applications.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Exa2.Applications.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }
        public DbSet<Student> tbl_student { get; set; }
        public DbSet<Subject> tbl_subject { get; set; }
        public DbSet<Mark> tbl_mark { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MarkEntityTypeConfiguration());

        }
    }
}
