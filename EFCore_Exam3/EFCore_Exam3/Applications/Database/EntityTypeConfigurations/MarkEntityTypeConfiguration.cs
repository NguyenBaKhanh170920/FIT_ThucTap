using EFCore_Exa2.Applications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Exa2.Applications.Database.EntityTypeConfigurations
{
    public class MarkEntityTypeConfiguration : IEntityTypeConfiguration<Mark>
    {
        public void Configure(EntityTypeBuilder<Mark> builder)
        {
            builder.ToTable("tbl_mark");
            builder.HasKey(x => x.Id).HasName("PK_MarkId");
            builder.Property(p => p.StudentId).HasColumnName("StudentId");
            builder.Property(p => p.SubjectId).HasColumnName("SubjectId");
            builder.Property(p => p.Scores).HasColumnName("Scores");
            builder.Property(p => p.CreateDate).HasColumnName("CreateDate");
            builder.HasOne(d => d.StudentNavigation).WithMany(p => p.Marks).HasForeignKey(p => p.StudentId)
                .HasConstraintName("FK_Student_Mark").OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.SubjectNavigation).WithMany(p => p.Marks).HasForeignKey(p => p.SubjectId)
                .HasConstraintName("FK_Subject_Mark").OnDelete(DeleteBehavior.Cascade);
        }
    }
}
