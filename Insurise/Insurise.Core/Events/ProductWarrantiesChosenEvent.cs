using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Events;

public class ProductWarrantiesChosenEvent : BaseDomainEvent
{
    public Warranty WarrantyChosen { get; private set; }
    public Product Product { get; private set; }

    public ProductWarrantiesChosenEvent(Product product, Warranty warrantyChosen)
    {
        Product = product;
        WarrantyChosen = warrantyChosen;
    }
}