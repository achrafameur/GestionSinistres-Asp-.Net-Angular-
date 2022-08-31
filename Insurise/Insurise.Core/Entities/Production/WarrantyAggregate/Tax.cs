using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class Tax : BaseEntity<int>
{
    private readonly HashSet<WarrantyTax> _warrantyTaxes;
    private readonly HashSet<ProductTax> _productTaxes;

    public Tax(string title, string description, double coefficient, double constant)
    {
        Title = title;
        Description = description;
        Coefficient = coefficient;
        Constant = constant;
        _warrantyTaxes = new HashSet<WarrantyTax>();
        _productTaxes = new HashSet<ProductTax>();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public double Coefficient { get; private set; }
    public double Constant { get; private set; }

    public IReadOnlyCollection<WarrantyTax> WarrantyTaxes => _warrantyTaxes;
    public IReadOnlyCollection<ProductTax> ProductTaxes => _productTaxes;
}