using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.WarrantyAggregate;
 
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class WarrantyFeaturesChosenEvent : BaseDomainEvent
{
    public Feature FeatureChosen { get; private set; }
    public Warranty Warranty { get; private set; }

    public WarrantyFeaturesChosenEvent(Warranty warranty, Feature featureChosen)
    {
        FeatureChosen = featureChosen;
        Warranty = warranty;
    }
}