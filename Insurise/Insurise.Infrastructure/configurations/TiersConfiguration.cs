using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class TiersConfiguration : IEntityTypeConfiguration<Tiers>
{
    public void Configure(EntityTypeBuilder<Tiers> builder)
    {
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Label).IsRequired();
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.TaxRegistrationNumber).IsRequired();
        builder.Property(e => e.Phone).IsRequired();
        builder.Property(e => e.Fax).IsRequired();
        builder.Property(e => e.Email).IsRequired();

        builder.HasOne(e => e.TiersCompany)
            .WithMany(c => c.Tiers)
            .HasForeignKey(s => s.TiersCompanyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}