using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customers>
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
