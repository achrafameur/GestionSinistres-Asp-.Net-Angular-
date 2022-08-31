using Insurise.Core.Entities.Production.WarrantyAggregate; 
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.ProductAggregate;

public class ProductWarranty : BaseEntity<int>
{
    public bool Mandatory { get; set; }
    public int Rank { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int WarrantyId { get; set; }
    public virtual Warranty Warranty { get; set; }
}