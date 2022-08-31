using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.ProductAggregate;

public class ProductFee : BaseEntity<int>
{ 

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int FeeId { get; set; }
    public virtual Fee Fee { get; set; }
    public int Rank { get; set  ; }
}
