 
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class Formula : BaseEntity<int>
{
    public Formula(string title, int type, string equation, int warrantyId)
    {
        Title = title;
        Type = type;
        Equation = equation;
        WarrantyId = warrantyId;
    }

    public string Title { get; private set; }
    public int Type { get; private set; }
    public string Equation { get; private set; }
    public int WarrantyId { get; private set; }
    public virtual Warranty Warranty { get; set; }
}