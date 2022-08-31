using Insurise.Core.Entities.Production.WarrantyAggregate;

namespace Insurise.Core.Entities.Production.ProductAggregate;

public class ProductTax
{
    public string Description { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int TaxId { get; set; }
    public Tax Tax { get; set; }
}