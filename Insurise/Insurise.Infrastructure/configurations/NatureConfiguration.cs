using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

internal class NatureConfiguration : IEntityTypeConfiguration<Nature>
{
    public void Configure(EntityTypeBuilder<Nature> builder)
    {
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(50);
    }
}