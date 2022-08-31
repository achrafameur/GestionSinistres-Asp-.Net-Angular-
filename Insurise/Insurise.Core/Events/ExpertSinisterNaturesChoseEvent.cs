using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class ExpertSinisterNaturesChoseEvent : BaseDomainEvent
{
    public SinisterNature SinisterNatureChosen { get; set; }
    public Expert Expert { get; set; }

    public ExpertSinisterNaturesChoseEvent(Expert expert,
        SinisterNature sinisterNatureChosen)
    {
        Expert = expert;
        SinisterNatureChosen = sinisterNatureChosen;
    }
}