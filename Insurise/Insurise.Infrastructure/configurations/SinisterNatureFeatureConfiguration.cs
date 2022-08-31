using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class SinisterNatureFeatureConfiguration : IEntityTypeConfiguration<SinisterNatureFeature>
{
    public void Configure(EntityTypeBuilder<SinisterNatureFeature> builder)
    {
        builder.HasOne(sc => sc.SinisterNature)
            .WithMany(s => s.SinisterNaturesFeatures)
            .HasForeignKey(sc => sc.SinisterNatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sc => sc.Feature)
            .WithMany(s => s.SinisterNaturesFeatures)
            .HasForeignKey(sc => sc.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}