using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductFeeConfiguration : IEntityTypeConfiguration<ProductFee>
{
    public void Configure(EntityTypeBuilder<ProductFee> builder)
    {
        builder.HasOne(sc => sc.Fee)
            .WithMany(s => s.ProductFees)
            .HasForeignKey(sc => sc.FeeId);


        builder.HasOne(sc => sc.Product)
            .WithMany(s => s.ProductFees)
            .HasForeignKey(sc => sc.ProductId);
    }
}
