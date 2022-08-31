using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class Commission : BaseEntity<int>
{
    private readonly List<WarrantyCommission> _warrantyCommissions;

    public Commission(decimal value)
    {
        Value = value;
        _warrantyCommissions = new List<WarrantyCommission>();
    }
   
    public decimal Value { get;  set; }

    public virtual IReadOnlyCollection<WarrantyCommission> WarrantyCommissions => _warrantyCommissions.AsReadOnly();
}