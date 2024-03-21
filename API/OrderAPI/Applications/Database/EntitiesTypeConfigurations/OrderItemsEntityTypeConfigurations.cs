using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Database.EntitiesTypeConfigurations
{
    public class OrderItemsEntityTypeConfigurations : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable(nameof(OrderItems));
            builder.HasKey(x => x.Id).HasName("PK_OrderItemId");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.ProductName).HasColumnName("ProductName");
            builder.Property(x => x.ProductId).HasColumnName("ProductId");
            builder.Property(x => x.Quantity).HasColumnName("Quantity");
        }
    }
}
