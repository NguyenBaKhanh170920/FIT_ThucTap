using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderAPI.Applications.Entities;

namespace OrderAPI.Applications.Database.EntitiesTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable(nameof(Products));
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.Price).HasColumnName("Price");
            builder.Property(p => p.RemainingAmount).HasColumnName("RemainingAmount");
        }
    }
}
