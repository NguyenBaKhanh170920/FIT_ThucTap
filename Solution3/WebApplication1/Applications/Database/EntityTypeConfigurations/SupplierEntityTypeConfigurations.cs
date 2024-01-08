using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class SupplierEntityTypeConfigurations : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable(nameof(Supplier));
            builder.HasKey(p => p.SupplierCode).HasName("PK_SupplierCode");
            builder.Property(p => p.SupplierCode).HasColumnName("SupplierCode");
            builder.Property(p => p.Address).HasColumnName("Address");
            builder.Property(p => p.Phone).HasColumnName("Phone");
            builder.Property(p => p.Email).HasColumnName("Email");
        }
    }
}
