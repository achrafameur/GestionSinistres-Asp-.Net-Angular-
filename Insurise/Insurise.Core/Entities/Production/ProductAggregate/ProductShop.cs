using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.ProductAggregate;

public class ProductShop : BaseEntity<int>
{
    public ProductShop(int productId , int shopId , double reduction, int defaultProduct)
    {
        ProductId = productId; 
        ShopId = shopId; 
        Reduction = reduction;
        DefaultProduct = defaultProduct;
    }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int ShopId { get; set; }
    public virtual Shop Shop { get; set; }
    public double Reduction { get; set  ; }
    public int DefaultProduct { get; set; }
}
