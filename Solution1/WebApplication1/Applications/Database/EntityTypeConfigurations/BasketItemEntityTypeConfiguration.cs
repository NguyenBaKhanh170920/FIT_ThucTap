using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class BasketItemEntityTypeConfiguration : IEntityTypeConfiguration<BasketItems>
    {
        public void Configure(EntityTypeBuilder<BasketItems> builder)
        {
            builder.ToTable(nameof(BasketItems));
            builder.HasKey(x => x.Id).HasName("PK_BasketItemId");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ProductId).HasColumnName("ProductId");
            builder.Property(x => x.ProductName).HasColumnName("ProductName");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
            builder.Property(x => x.Status).HasColumnName("Status");
        }
    }
}
