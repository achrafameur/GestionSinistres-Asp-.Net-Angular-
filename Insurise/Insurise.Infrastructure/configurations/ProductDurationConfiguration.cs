using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductDurationConfiguration : IEntityTypeConfiguration<ProductDuration>
{
    public DbSet<ProductDuration> ProductDurations { get; set; } = null!;

    public void Configure(EntityTypeBuilder<ProductDuration> builder)
    {
        // builder.HasKey(sc => new {sc.DurationId, sc.ProductId});


        builder.HasOne(sc => sc.Duration)
            .WithMany(s => s.ProductDurations)
            .HasForeignKey(sc => sc.DurationId);


        builder.HasOne(sc => sc.Product)
            .WithMany(s => s.ProductDurations)
            .HasForeignKey(sc => sc.ProductId);
    }
}
