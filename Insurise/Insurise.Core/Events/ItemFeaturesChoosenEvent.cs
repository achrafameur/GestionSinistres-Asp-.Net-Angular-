using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class ItemFeaturesChoosenEvent : BaseDomainEvent
{
    public Feature FeatureChoosen { get; set; }
    public Item Item { get; set; }

    public ItemFeaturesChoosenEvent(Item item, Feature featureChoosen)
    {
        FeatureChoosen = featureChoosen;
        Item = item;
    }
}