using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class SinisterNatureFeature : BaseEntity<int>
{
    public int FeatureId { get; set; }
    public Feature? Feature { get; set; }
    public int SinisterNatureId { get; set; }
    public SinisterNature? SinisterNature { get; set; }
}