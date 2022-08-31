using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class StatusConfiguration : IEntityTypeConfiguration<Status>
{
    public void Configure(EntityTypeBuilder<Status> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Symbol).IsRequired().HasMaxLength(100);

        builder.HasOne(e => e.Item)
            .WithMany(c => c.Status)
            .HasForeignKey(s => s.ItemId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}