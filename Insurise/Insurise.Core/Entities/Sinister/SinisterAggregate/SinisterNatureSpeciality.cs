using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class SinisterNatureSpeciality : BaseEntity<int>
{
    public int ChainElementId { get; set; }
    public ChainElement? ChainElement { get; set; }
    public int SinisterNatureId { get; set; }
    public SinisterNature? SinisterNature { get; set; }
}