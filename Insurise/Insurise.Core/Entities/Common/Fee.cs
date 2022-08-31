using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Fee : BaseEntity<int>
{

    private readonly List<ProductFee> _ProductFees;
    public virtual IEnumerable<ProductFee> ProductFees => _ProductFees.AsReadOnly();
    public Fee(string title, string symbol, string description, FeesType type, string equation)
    {
        Title = title;
        Symbol = symbol;
        Description = description;
        Type = type;
        Equation = equation;
    }

    public string Title { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; }
    public string Equation { get; set; }
    public FeesType Type { get; set; }
}
