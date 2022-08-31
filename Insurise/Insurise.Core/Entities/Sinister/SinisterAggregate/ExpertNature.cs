using Insurise.Core.Entities.Common;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class ExpertNature
{
    public bool Mandatory { get; set; }
    public int ExpertId { get; set; }
    public Expert Expert { get; set; }
    public int NatureId { get; set; }
    public Nature Nature { get; set; }
}