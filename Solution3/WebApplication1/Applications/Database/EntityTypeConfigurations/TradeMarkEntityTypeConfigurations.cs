using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Applications.Entities;

namespace WebApplication1.Applications.Database.EntityTypeConfigurations
{
    public class TradeMarkEntityTypeConfigurations : IEntityTypeConfiguration<TradeMark>
    {
        public void Configure(EntityTypeBuilder<TradeMark> builder)
        {
            builder.ToTable(nameof(TradeMark));
            builder.HasKey(p => p.TradeMarkId).HasName("PK_TradeMarkId");
            builder.Property(p => p.TradeMarkId).HasColumnName("TradeMarkId");
            builder.Property(p => p.TradeMarkName).HasColumnName("TradeMarkName");
        }
    }
}
