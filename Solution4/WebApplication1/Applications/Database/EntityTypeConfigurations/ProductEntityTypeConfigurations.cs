using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class ProductEntityTypeConfigurations : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable(nameof(Products));
            builder.HasKey(p => p.ProductId).HasName("PK_ProductId");
            builder.Property(p => p.ProductId).HasColumnName("ProductId");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.AvailableQuantity).HasColumnName("AvailableQuantity");
            builder.Property(p => p.Image).HasColumnName("Image");
        }
    }
}
