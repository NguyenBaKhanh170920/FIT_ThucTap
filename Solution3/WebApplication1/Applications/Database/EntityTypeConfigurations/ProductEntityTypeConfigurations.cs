using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class ProductEntityTypeConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(p => p.ProductCode).HasName("PK_ProductCode");
            builder.Property(p => p.ProductCode).HasColumnName("ProductCode");
            builder.Property(p => p.ProductName).HasColumnName("ProductName");
            builder.Property(p => p.Image).HasColumnName("Image");
            builder.Property(p => p.Cost).HasColumnName("Cost");
            builder.Property(p => p.RentailPrice).HasColumnName("RentailPrice");
            builder.Property(p => p.Inventory).HasColumnName("Inventory");
            builder.Property(p => p.Unit).HasColumnName("Unit");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.CategoryId).HasColumnName("CategoryId");
            builder.Property(p => p.TradekMarkId).HasColumnName("TradekMarkId");
        }
    }
}
