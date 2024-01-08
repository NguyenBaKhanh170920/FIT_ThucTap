using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class StatusEntityTypeConfigurations : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable(nameof(Status));
            builder.HasKey(x => x.Id).HasName("PK_Id");
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Paid).HasColumnName("Paid");
            builder.Property(p => p.Deposit).HasColumnName("Deposit");
            builder.Property(p => p.Unpaid).HasColumnName("Unpaid");
        }
    }
}
