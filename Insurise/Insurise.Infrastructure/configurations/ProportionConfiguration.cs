using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProportionConfiguration : IEntityTypeConfiguration<Proportion>
{
    public void Configure(EntityTypeBuilder<Proportion> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(s => s.Occurence)
            .IsRequired();
        builder.Property(d => d.AdditionalCosts)
            .IsRequired();

       
    }
}
