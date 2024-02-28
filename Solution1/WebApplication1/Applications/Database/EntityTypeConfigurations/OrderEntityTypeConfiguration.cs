using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable(nameof(Orders));
            builder.HasKey(x => x.Id).HasName("PK_OrderId");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.OrderDate).HasColumnName("OrderDate");
            builder.Property(x => x.CustomerId).HasColumnName("CustomerId");
            builder.Property(x => x.Street).HasColumnName("Street");
            builder.Property(x => x.City).HasColumnName("City");
            builder.Property(x => x.District).HasColumnName("District");
            builder.Property(x => x.AdditionalAddress).HasColumnName("AdditionalAddress");
            var navigation = builder.Metadata.FindNavigation(nameof(Orders.OrderItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
