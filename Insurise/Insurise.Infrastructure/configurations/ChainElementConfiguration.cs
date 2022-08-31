using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ChainElementConfiguration : IEntityTypeConfiguration<ChainElement>
{
    public void Configure(EntityTypeBuilder<ChainElement> builder)
    {
        builder.Property(e => e.Title)
             .IsRequired()
             .HasMaxLength(50);
        builder.HasOne(s => s.Chain)
            .WithMany(g => g.Elements)
            .HasForeignKey(e => e.ChainId);

    }
}