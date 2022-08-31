using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ChainSinisterNatureConfiguration : IEntityTypeConfiguration<ChainSinisterNature>
{
    public void Configure(EntityTypeBuilder<ChainSinisterNature> builder)
    {
        builder.HasKey(bc => new {bc.ChainId, bc.SinisterNatureId});

        // builder.HasOne(sc => sc.Chain).WithMany(s => s.SinisterNature)
        //     .HasForeignKey(sc => sc.ChainId);
        //
        // builder.HasOne(sc => sc.SinisterNature).WithMany(s => s.Chain_Sinisternatures)
        //     .HasForeignKey(sc => sc.SinisterNatureId);
    }
}