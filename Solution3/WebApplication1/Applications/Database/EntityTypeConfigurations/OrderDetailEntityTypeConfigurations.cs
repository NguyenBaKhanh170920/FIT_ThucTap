using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class OrderDetailEntityTypeConfigurations : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable(nameof(OrderDetail));
            builder.HasKey(p => p.OrderDetailId).HasName("PK_OrderDetailId");
            builder.Property(p => p.OrderDetailId).HasColumnName("OrderDetailId");
            builder.Property(p => p.ProductCode).HasColumnName("ProductCode");
            builder.Property(p => p.OrderCode).HasColumnName("OrderCode");
            builder.Property(p => p.NumberProduct).HasColumnName("NumberProduct");
            builder.Property(p => p.TotalPrice).HasColumnName("TotalPrice");
            builder.Property(p => p.Sale).HasColumnName("Sale");
            builder.Property(p => p.OrderDate).HasColumnName("OrderDate");
        }
    }
}
