using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class SinisterNatureExpertConfiguration : IEntityTypeConfiguration<SinisterNatureExpert>
{
    public void Configure(EntityTypeBuilder<SinisterNatureExpert> builder)
    {
        builder.HasKey(bc => new {bc.ExpertId, bc.SinisterNatureId});

        builder.HasOne(sc => sc.Expert)
            .WithMany(s => s.ExpertSinisterNatures)
            .HasForeignKey(sc => sc.ExpertId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sc => sc.SinisterNature)
            .WithMany(s => s.Experts)
            .HasForeignKey(sc => sc.SinisterNatureId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}