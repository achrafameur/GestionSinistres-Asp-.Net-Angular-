using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductShopConfiguration : IEntityTypeConfiguration<ProductShop>
{
    public void Configure(EntityTypeBuilder<ProductShop> builder)
    {
        builder.HasOne(sc => sc.Product)
           .WithMany(s => s.ProductShops)
           .HasForeignKey(sc => sc.ProductId);

        builder.HasOne(sc => sc.Shop)
            .WithMany(s => s.ProductShops)
            .HasForeignKey(sc => sc.ShopId); 
    }
}
