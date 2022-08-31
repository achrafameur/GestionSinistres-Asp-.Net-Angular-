using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class ProductDurationProportion : BaseEntity<int>
{
    public ProductDurationProportion(int proportionId, int productDurationId, string title)
    {
        ProportionId = proportionId;
        ProductDurationId = productDurationId;
        this.title = title;
    }

    public int ProportionId { get; set; }
    public Proportion Proportion { get; set; }

    public int ProductDurationId { get; set; }
    public ProductDuration ProductDuration { get; set; }

    public string title { get; set; }
}
