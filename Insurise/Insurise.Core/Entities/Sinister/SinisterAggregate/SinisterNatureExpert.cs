using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class SinisterNatureExpert : BaseEntity<int>
{
    public bool Mandatory { get; set; }
    public int SinisterNatureId { get; set; }
    public SinisterNature? SinisterNature { get; set; }
    public int ExpertId { get; set; }
    public Expert? Expert { get; set; }
}