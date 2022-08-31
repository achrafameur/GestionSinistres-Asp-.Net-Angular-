using Insurise.Core.Entities.Production.WarrantyAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations;

public class FormulaConfiguration : IEntityTypeConfiguration<Formula>
{
    public void Configure(EntityTypeBuilder<Formula> builder)
    {
        builder.Property(e => e.Title).IsRequired().HasMaxLength(30);
        builder.Property(e => e.Equation).IsRequired();
    }
}