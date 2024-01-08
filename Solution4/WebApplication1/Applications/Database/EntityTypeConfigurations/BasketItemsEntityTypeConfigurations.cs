using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class BasketItemsEntityTypeConfigurations : IEntityTypeConfiguration<BasketItems>
    {
        public void Configure(EntityTypeBuilder<BasketItems> builder)
        {
            builder.ToTable(nameof(BasketItems));
            builder.HasKey(p => p.Id).HasName("PK_BasketItemsId");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ProductName).HasColumnName("ProductName");
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.Quantity).HasColumnName("Quantity");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.Image).HasColumnName("Image");
        }
    }
}
