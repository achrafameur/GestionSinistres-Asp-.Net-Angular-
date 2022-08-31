using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class MandatoryDocumentConfiguration : IEntityTypeConfiguration<MandatoryDocument>
{
    public DbSet<MandatoryDocument> MandatoryDocuments { get; set; } = null!;

    public void Configure(EntityTypeBuilder<MandatoryDocument> builder)
    {
        builder.Property(e => e.Title).IsRequired();
    }
}