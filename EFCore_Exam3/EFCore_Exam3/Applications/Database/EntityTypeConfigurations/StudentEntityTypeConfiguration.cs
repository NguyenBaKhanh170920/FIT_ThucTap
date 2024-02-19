using EFCore_Exa2.Applications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Exa2.Applications.Database.EntityTypeConfigurations
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("tbl_student");
            builder.HasKey(p => p.Id).HasName("PK_StudentId");
            builder.Property(p => p.Id).HasColumnName("StudentId");
            builder.Property(p => p.Name).HasColumnName("StudentName");
            builder.Property(p => p.Birthday).HasColumnName("Birthday");
            builder.Property(p => p.Gender).HasColumnName("Gender");
            builder.Property(p => p.Status).HasColumnName("Status");
        }
    }
}
