using BasketAPI.Applications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketAPI.Applications.Database.EntitiesTypeConfigurations
{
    public class BasketItemsEntityTypeConfiguration : IEntityTypeConfiguration<BasketItems>
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
