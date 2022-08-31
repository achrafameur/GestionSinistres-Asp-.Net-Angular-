using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ExpertNatureConfiguration : IEntityTypeConfiguration<ExpertNature>
{
    public void Configure(EntityTypeBuilder<ExpertNature> builder)
    {
        builder.HasKey(bc => new {bc.ExpertId, bc.NatureId});

        builder.HasOne(sc => sc.Expert).WithMany(s => s.ExpertNatures)
            .HasForeignKey(sc => sc.ExpertId);
       
    }
}