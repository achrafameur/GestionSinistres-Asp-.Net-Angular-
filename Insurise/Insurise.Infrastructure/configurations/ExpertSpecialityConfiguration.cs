using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ExpertSpecialityConfiguration : IEntityTypeConfiguration<ExpertSpeciality>
{
    public void Configure(EntityTypeBuilder<ExpertSpeciality> builder)
    {
        builder.HasKey(bc => new {bc.ExpertId, bc.ChainElementId });

        builder.HasOne(sc => sc.Expert).WithMany(s => s.ExpertSpecialities)
            .HasForeignKey(sc => sc.ExpertId);

        builder.HasOne(sc => sc.ChainElement).WithMany(s => s.ExpertSpecialities)
            .HasForeignKey(sc => sc.ChainElementId);
    }
}