using Insurise.Core.Entities.Production.WarrantyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class WarrantyConfiguration : IEntityTypeConfiguration<Warranty>
{
    public void Configure(EntityTypeBuilder<Warranty> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
       

        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
        builder.HasOne(s => s.Formula)
            .WithOne(ad => ad.Warranty)
            .HasForeignKey<Formula>(ad => ad.WarrantyId);

        builder.HasOne(s => s.Rate)
            .WithOne(ad => ad.Warranty)
            .HasForeignKey<Rate>(ad => ad.WarrantyId);


    }
}