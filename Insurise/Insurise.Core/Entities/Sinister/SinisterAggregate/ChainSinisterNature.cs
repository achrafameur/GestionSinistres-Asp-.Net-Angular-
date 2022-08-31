using Insurise.Core.Entities.Common;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class ChainSinisterNature
{
    public int ChainId { get; set; }
    public Chain Chain { get; set; }
    public int SinisterNatureId { get; set; }
    public SinisterNature SinisterNature { get; set; }
}