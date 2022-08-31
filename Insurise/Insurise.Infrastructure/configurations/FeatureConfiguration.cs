using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
{ 

    public void Configure(EntityTypeBuilder<Feature> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Fixed).HasMaxLength(30);
        builder.Property(e => e.Minimum).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Maximum).IsRequired().HasMaxLength(30);

       
    }
}