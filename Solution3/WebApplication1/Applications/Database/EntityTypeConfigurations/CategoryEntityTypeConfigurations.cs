using Microsoft.EntityFrameworkCore;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class CategoryEntityTypeConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(p => p.CategoryId).HasName("PK_CategoryId");
            builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
            builder.Property(p => p.CategoryName).HasColumnName("CategoryName");
        }
    }
}
