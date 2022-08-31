using Insurise.Core.Entities.Production.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasIndex(u => u.Title).IsUnique();
       

        builder.ToTable(nameof(Product));
        builder.HasKey(x => x.Id);

        builder
            .Property(e => e.StartDate)
            .HasPrecision(0);
        builder
            .Property(e => e.ExpirationDate)
            .HasPrecision(0);

        builder.HasOne(p => p.Branch)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BranchId);

        builder
            .HasMany(p => p.Children)
            .WithMany(p => p.ProductParent)
            .UsingEntity<Dictionary<string, object>>(
                "ProductProduct",
                j => j
                    .HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("productParentId")
                    .HasConstraintName("FK_productProduct_productParent_productParentId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("productChildId")
                    .HasConstraintName("FK_productProduct_productChild_productChildId")
                    .OnDelete(DeleteBehavior.ClientCascade));
    }
}
