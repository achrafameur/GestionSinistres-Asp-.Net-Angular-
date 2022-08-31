using Insurise.Core.Entities.Production.WarrantyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class WarrantyCommissionConfiguration : IEntityTypeConfiguration<WarrantyCommission>
{
    public void Configure(EntityTypeBuilder<WarrantyCommission> builder)
    {
        /*  builder.HasKey(sc => new {sc.WarrantyId, sc.CommissionId});*/
        builder.HasOne(sc => sc.Commission)
           .WithMany(s => s.WarrantyCommissions)
           .HasForeignKey(s => s.CommissionId);

        builder.HasOne(sc => sc.Warranty)
            .WithMany(s => s.WarrantyCommissions)
            .HasForeignKey(sc => sc.WarrantyId);
       
    }
}