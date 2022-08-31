using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class WarrantyUpdatedEvent : BaseDomainEvent
{
    public WarrantyUpdatedEvent(Warranty warrantyUpdated)
    {
        WarrantyUpdated = warrantyUpdated;
    }

    public int Id { get; private set; }
    public Warranty WarrantyUpdated { get; }
}