using Insurise.Core.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.Metadata.FindNavigation(nameof(Branch.SinisterNatures))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Branch.Children))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);
        builder.Metadata.FindNavigation(nameof(Branch.Products))
            ?.SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.HasOne(x => x.BranchParent)
            .WithMany(x => x.Children)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Description).IsRequired().HasMaxLength(30);
    }
}