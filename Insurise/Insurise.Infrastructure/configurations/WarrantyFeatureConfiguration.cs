using Insurise.Core.Entities.Production.WarrantyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class WarrantyFeatureConfiguration : IEntityTypeConfiguration<WarrantyFeature>
{
   /* public DbSet<WarrantyFeature> FeatureWarranties { get; set; } = null!;*/

    public void Configure(EntityTypeBuilder<WarrantyFeature> builder)
    {
        //  builder.HasKey(sc => new {sc.WarrantyId, sc.FeatureId});
        builder.HasOne(sc => sc.Warranty)
            .WithMany(s => s.WarrantyFeatures)
            .HasForeignKey(sc => sc.WarrantyId);


        builder.HasOne(sc => sc.Feature)
            .WithMany(s => s.Warranties)
            .HasForeignKey(sc => sc.FeatureId);
    }
}