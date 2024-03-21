using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Database.EntitiesTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable(nameof(Orders));
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.Amount).HasColumnName("Amount");
            builder.Property(p => p.Status).HasColumnName("Status");
            builder.Property(p => p.ErrorCode).HasColumnName("ErrorCode");
            builder.Property(p => p.ErrorMessage).HasColumnName("ErrorMessage");
            builder.Property(p => p.CreatedAt).HasColumnName("CreatedAt");
        }
    }
}
