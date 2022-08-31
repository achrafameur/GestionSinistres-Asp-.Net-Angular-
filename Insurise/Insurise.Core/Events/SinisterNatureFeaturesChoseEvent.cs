using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class SinisterNatureFeaturesChoseEvent : BaseDomainEvent
{
    public Feature FeatureChosen { get; set; }
    public SinisterNature SinisterNature { get; set; }

    public SinisterNatureFeaturesChoseEvent(SinisterNature sinisterNature,
        Feature featureChosen)
    {
        SinisterNature = sinisterNature;
        FeatureChosen = featureChosen;
    }
}