using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Proportion : BaseEntity<int>
{
    private readonly List<ProductDurationProportion> _proportionDurations = new();
    public virtual IEnumerable<ProductDurationProportion> ProportionDurations => _proportionDurations.AsReadOnly();

    public Proportion(string title, int occurence, float additionalCosts)
    {
        Title = title;
        Occurence = occurence;
        AdditionalCosts = additionalCosts; 
    }

    public string Title { get; set; }
    public int Occurence { get; set; }
    public float AdditionalCosts { get; set; }


}
