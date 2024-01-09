using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class OrderItemEntityTypeConfigurations : IEntityTypeConfiguration<OrderItems>
    {
        public void Configure(EntityTypeBuilder<OrderItems> builder)
        {
            builder.ToTable(nameof(OrderItems));
            builder.HasKey(p => p.Id).HasName("PK_Id");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ProductName).HasColumnName("ProductName");
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.Quantity).HasColumnName("Quantity");
        }
    }
}
