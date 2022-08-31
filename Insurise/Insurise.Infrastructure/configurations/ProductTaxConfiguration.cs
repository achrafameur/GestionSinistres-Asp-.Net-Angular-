using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductTaxConfiguration : IEntityTypeConfiguration<ProductTax>
{
    public void Configure(EntityTypeBuilder<ProductTax> builder)
    {
        builder.HasKey(sc => new {sc.TaxId, sc.ProductId});

        builder.HasOne(sc => sc.Tax)
            .WithMany(s => s.ProductTaxes)
            .HasForeignKey(sc => sc.TaxId);

        builder.HasOne(sc => sc.Product)
            .WithMany(s => s.ProductTaxes)
            .HasForeignKey(sc => sc.ProductId);
    }
}