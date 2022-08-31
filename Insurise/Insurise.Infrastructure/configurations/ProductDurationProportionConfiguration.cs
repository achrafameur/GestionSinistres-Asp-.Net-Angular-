using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductDurationProportionConfiguration : IEntityTypeConfiguration<ProductDurationProportion>
{
    public DbSet<ProductDurationProportion> ProductDurations { get; set; } = null!;

    public void Configure(EntityTypeBuilder<ProductDurationProportion> builder)
    { 

        builder.HasOne(sc => sc.ProductDuration)
            .WithMany(s => s.Proportions)
            .HasForeignKey(sc => sc.ProductDurationId);
         
    }
}
