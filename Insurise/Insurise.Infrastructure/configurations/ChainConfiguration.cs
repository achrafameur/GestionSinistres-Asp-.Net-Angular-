using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ChainConfiguration : IEntityTypeConfiguration<Chain>
{
    public void Configure(EntityTypeBuilder<Chain> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);

       
    }
}