using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Database.EntitiesTypeConfigurations
{
    public class CustomerEntityTypeConfigurations : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable(nameof(Customers));
            builder.HasKey(x => x.Id).HasName("PK_CustomerId");
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(x => x.Name).HasColumnName("Name");
        }
    }
}
