using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.ProductAggregate;

public class ProductDuration : BaseEntity<int>
{
    private readonly List<ProductDurationProportion> _proportions = new(); 
    public virtual IEnumerable<ProductDurationProportion> Proportions => _proportions.AsReadOnly();
   
    public ProductDuration(int productId, int durationId,  bool actif)
    {
        ProductId = productId; 
        DurationId = durationId; 
        this.actif = actif;
    }
     

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int DurationId { get; set; }
    public virtual Duration Duration { get; set; }

    public bool actif { get; set; }

    public void AddProductDurationProportion(List<ProductDurationProportion> productDurationProportion)
    {
        _proportions.AddRange(productDurationProportion);
    }
    public void RemoveProductDurationsProportions(List<ProductDurationProportion> productDurationProportions)
    {
        foreach (var productDurationProportion in productDurationProportions)
        {
            productDurationProportion.IsDeleted = true;
        }
    }
}
