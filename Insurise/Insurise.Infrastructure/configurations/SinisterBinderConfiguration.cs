using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Insurise.Infrastructure.Configurations
{
    public class SinisterBinderConfiguration : IEntityTypeConfiguration<SinisterBinder>
    {
        public void Configure(EntityTypeBuilder<SinisterBinder> builder)
        {

            builder.Property(e => e.SinisterTime).IsRequired();
            builder.Property(e => e.SinisterDate).IsRequired();
            builder.Property(e => e.SinisterPlace).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.InsuredName).IsRequired();
            builder.Property(e => e.InsuredObject).IsRequired();
            builder.Property(e => e.PolicyNumber).IsRequired();
            builder.Property(e => e.ReclamationDate).IsRequired();
        }
    }
}
