using BasketAPI.Applications.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BasketAPI.Applications.Database.EntitiesTypeConfigurations
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
