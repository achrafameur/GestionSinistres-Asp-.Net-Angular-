using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class SinisterNatureMandatoryDocumentConfiguration : IEntityTypeConfiguration<SinisterNatureMandatoryDocument>
{
    public DbSet<SinisterNatureMandatoryDocument> SinisterNaturMandatoryDocuments { get; set; } = null!;

    public void Configure(EntityTypeBuilder<SinisterNatureMandatoryDocument> builder)
    {
        builder.HasOne(sc => sc.SinisterNature)
            .WithMany(s => s.SinisterNaturesMandatoryDocuments)
            .HasForeignKey(sc => sc.SinisterNatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sc => sc.MandatoryDocument)
            .WithMany(s => s.SinisterNaturesMandatoryDocuments)
            .HasForeignKey(sc => sc.MandatoryDocumentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}