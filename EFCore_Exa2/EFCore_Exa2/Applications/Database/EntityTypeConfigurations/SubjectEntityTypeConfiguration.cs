using EFCore_Exa2.Applications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Exa2.Applications.Database.EntityTypeConfigurations
{
    public class SubjectEntityTypeConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("tbl_subject");
            builder.HasKey(p => p.Id).HasName("PK_SubjectId");
            builder.Property(p => p.Id).HasColumnName("SubjectId");
            builder.Property(p => p.Name).HasColumnName("SubjectName");
            builder.Property(p => p.Status).HasColumnName("Status");
        }
    }
}
