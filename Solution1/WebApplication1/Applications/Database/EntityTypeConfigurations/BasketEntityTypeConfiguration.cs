using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class BasketEntityTypeConfiguration : IEntityTypeConfiguration<Baskets>
    {
        public void Configure(EntityTypeBuilder<Baskets> builder)
        {
            builder.ToTable(nameof(Baskets));
            builder.HasKey(p => p.CustomerId).HasName("PK_BasketId");
            builder.Property(p => p.CustomerId).HasColumnName("CustomerId");
            var navigation = builder.Metadata.FindNavigation(nameof(Baskets.BasketItems));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
