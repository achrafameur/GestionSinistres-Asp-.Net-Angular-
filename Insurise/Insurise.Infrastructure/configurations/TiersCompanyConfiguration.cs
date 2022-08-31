using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class TiersCompanyConfiguration : IEntityTypeConfiguration<TiersCompany>
{
    public void Configure(EntityTypeBuilder<TiersCompany> builder)
    {
        builder.Property(e => e.TaxRegistrationNumber).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Label).IsRequired().HasMaxLength(50);
        builder.Property(e => e.Description).IsRequired();
        builder.Property(e => e.Phone).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Fax).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Email).IsRequired();
        builder.Property(e => e.Address).IsRequired();
    }
}