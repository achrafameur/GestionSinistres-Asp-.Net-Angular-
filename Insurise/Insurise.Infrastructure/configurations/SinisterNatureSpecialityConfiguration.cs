using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class SinisterNatureSpecialityConfiguration : IEntityTypeConfiguration<SinisterNatureSpeciality>
{
    public DbSet<SinisterNatureSpeciality> SinisterNatureSpecialities { get; set; } = null!;
    public void Configure(EntityTypeBuilder<SinisterNatureSpeciality> builder)
    {
        builder.HasOne(sc => sc.SinisterNature)
           .WithMany(s => s.SinisterNaturesSpecialities)
           .HasForeignKey(sc => sc.SinisterNatureId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sc => sc.ChainElement)
            .WithMany(s => s.SinisterNaturesSpecialities)
            .HasForeignKey(sc => sc.ChainElementId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
