using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class ExpertConfiguration : IEntityTypeConfiguration<Expert>
{
    public void Configure(EntityTypeBuilder<Expert> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Code).IsRequired();
        builder.Property(e => e.FName).IsRequired().HasMaxLength(30);
        builder.Property(e => e.LName).IsRequired().HasMaxLength(30);
        builder.Property(e => e.TypeExpert).IsRequired();
        builder.Property(e => e.Address).IsRequired();
        builder.Property(e => e.BirthDate).IsRequired();
        builder.Property(e => e.CancellationDate).IsRequired();
        builder.Property(e => e.Cin).IsRequired();
        builder.Property(e => e.Email).IsRequired();
        builder.Property(e => e.Fax).IsRequired();
        builder.Property(e => e.Fixe).IsRequired().HasMaxLength(8);
        builder.Property(e => e.Governorate).IsRequired();
        builder.Property(e => e.RegistrationDate).IsRequired();
        builder.Property(e => e.SexId).IsRequired();
        builder.Property(e => e.Tel).IsRequired().HasMaxLength(8);
    }
}