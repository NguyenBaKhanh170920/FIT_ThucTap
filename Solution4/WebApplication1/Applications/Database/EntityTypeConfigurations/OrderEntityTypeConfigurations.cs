using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class OrderEntityTypeConfigurations : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable(nameof(Orders));
            builder.HasKey(p => p.Id).HasName("PK_OrderId");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.OrderDate).HasColumnName("OrderDate");
            builder.Property(p => p.Street).HasColumnName("Street");
            builder.Property(p => p.City).HasColumnName("City");
            builder.Property(p => p.District).HasColumnName("District");
            builder.Property(p => p.AdditionalAddress).HasColumnName("AdditionalAddress");
        }
    }
}
