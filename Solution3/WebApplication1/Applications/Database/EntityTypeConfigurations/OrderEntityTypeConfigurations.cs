using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class OrderEntityTypeConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(p => p.OrderCode).HasName("PK_OrderCode");
            builder.Property(p => p.OrderCode).HasColumnName("OrderCode");
            builder.Property(p => p.OrderDate).HasColumnName("OrderDate");
            builder.Property(p => p.DeliveryDate).HasColumnName("DeliveryDate");
            builder.Property(p => p.TotalPrice).HasColumnName("TotalPrice");
            builder.Property(p => p.Email).HasColumnName("Email");
            builder.Property(p => p.Phone).HasColumnName("Phone");
            builder.Property(p => p.Address).HasColumnName("Address");
            builder.Property(p => p.seller).HasColumnName("seller");
            builder.Property(p => p.Paid).HasColumnName("Paid");
            builder.Property(p => p.Sale).HasColumnName("Sale");
            builder.Property(p => p.Status).HasColumnName("Status");
        }
    }
}
