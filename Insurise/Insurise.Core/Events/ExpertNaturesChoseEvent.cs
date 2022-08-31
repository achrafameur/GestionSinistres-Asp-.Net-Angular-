using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class ExpertNaturesChoseEvent : BaseDomainEvent
{
    public Nature NatureChosen { get; set; }
    public Expert Expert { get; set; }

    public ExpertNaturesChoseEvent(Expert expert,
        Nature natureChosen)
    {
        Expert = expert;
        NatureChosen = natureChosen;
    }
}