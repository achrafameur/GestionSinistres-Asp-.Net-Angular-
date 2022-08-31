using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductWarrantyConfiguration : IEntityTypeConfiguration<ProductWarranty>
{
    public void Configure(EntityTypeBuilder<ProductWarranty> builder)
    {
        builder.HasOne(sc => sc.Warranty)
            .WithMany(s => s.ProductWarranties)
            .HasForeignKey(sc => sc.WarrantyId);


        builder.HasOne(sc => sc.Product)
            .WithMany(s => s.ProductWarranties)
            .HasForeignKey(sc => sc.ProductId);
    }
}
