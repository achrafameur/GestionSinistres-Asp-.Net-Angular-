using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class SinisterNatureConfiguration : IEntityTypeConfiguration<SinisterNature>
{
    public void Configure(EntityTypeBuilder<SinisterNature> builder)
    {
        builder.Property(e => e.Title).IsRequired();
        builder.Property(e => e.Code).IsRequired();
        builder.Property(e => e.BranchId).IsRequired();
        builder.Property(e => e.IdaEnabled).IsRequired();
        builder.Property(e => e.TransactionEnabled).IsRequired();
        builder.Property(e => e.ThirdPartyEnabled).IsRequired();
        builder.Property(e => e.VictimEnabled).IsRequired();
        builder.Property(e => e.RespEnabled).IsRequired();
        builder.Property(e => e.RespAutoEnabled).IsRequired();
        builder.Property(e => e.AffaireEnabled).IsRequired();
        builder.Property(e => e.ExpertiseEnabled).IsRequired();
        builder.Property(e => e.EvalInterneEnabled).IsRequired();
        builder.Property(e => e.EvalInterneCorpEnabled).IsRequired();
        builder.Property(e => e.RegExpertEnabled).IsRequired();

        builder.HasOne(e => e.Branch)
            .WithMany(c => c.SinisterNatures)
            .HasForeignKey(s => s.BranchId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}