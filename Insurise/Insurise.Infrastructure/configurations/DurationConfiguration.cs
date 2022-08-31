using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class DurationConfiguration : IEntityTypeConfiguration<Duration>
{
    public void Configure(EntityTypeBuilder<Duration> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Type).IsRequired(); 
        builder.Property(e => e.Coefficient).IsRequired();
        builder.Property(e => e.Value).IsRequired(); 
        builder.Property(e => e.Renewable).IsRequired();
    }
}
