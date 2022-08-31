using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class FeatureItemConfiguration : IEntityTypeConfiguration<FeatureItem>
{
    public void Configure(EntityTypeBuilder<FeatureItem> builder)
    {
        /*  builder.HasKey(sc => new { sc.ItemId, sc.FeatureId });*/
        builder.HasOne(sc => sc.Feature)
             .WithMany(s => s.FeatureItems)
             .HasForeignKey(s => s.FeatureId);

        builder.HasOne(sc => sc.Item)
            .WithMany(s => s.FeatureItems)
            .HasForeignKey(sc => sc.ItemId);


       

    }
}