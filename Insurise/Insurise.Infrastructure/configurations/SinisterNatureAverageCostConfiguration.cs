using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class SinisterNatureAverageCostConfiguration : IEntityTypeConfiguration<SinisterNatureAverageCost>
{
    public void Configure(EntityTypeBuilder<SinisterNatureAverageCost> builder)
    {
        builder.Property(e => e.AverageCost).IsRequired();
        builder.Property(e => e.DateStart).IsRequired();
        builder.Property(e => e.DateEnd).IsRequired();

        builder.HasOne(e => e.SinisterNature)
            .WithMany(c => c.SinisterNatureAvgerageCosts)
            .HasForeignKey(s => s.SinisterNatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}