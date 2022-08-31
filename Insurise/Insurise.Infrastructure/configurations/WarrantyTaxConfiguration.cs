using Insurise.Core.Entities.Production.WarrantyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class WarrantyTaxConfiguration : IEntityTypeConfiguration<WarrantyTax>
{
    public void Configure(EntityTypeBuilder<WarrantyTax> builder)
    {
       /* builder.HasKey(sc => new {sc.TaxId, sc.WarrantyId});*/

        builder.HasOne(sc => sc.Tax)
            .WithMany(s => s.WarrantyTaxes)
            .HasForeignKey(sc => sc.TaxId);

        builder.HasOne(sc => sc.Warranty)
            .WithMany(s => s.WarrantyTaxes)
            .HasForeignKey(sc => sc.WarrantyId);
    }
}