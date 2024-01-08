using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class CustomerEntityTypeConfigurations : IEntityTypeConfiguration<Customers>
    {
        public void Configure(EntityTypeBuilder<Customers> builder)
        {
            builder.ToTable(nameof(Customers));
            builder.HasKey(p => p.Id).HasName("PK_CustomersId");
            builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Street).HasColumnName("Street");
            builder.Property(p => p.City).HasColumnName("City");
            builder.Property(p => p.District).HasColumnName("District");
            builder.Property(p => p.AdditionalAddress).HasColumnName("AdditionalAddress");
        }
    }
}
