using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Duration : BaseEntity<int>
{
    private readonly List<ProductDuration> _productDurations;

    public Duration(string title, string type, int value, double coefficient, string? startDate, string? endDate,
        bool renewable)
    {
        Title = title;
        Type = type;
        Value = value;
        Coefficient = coefficient;
        StartDate = startDate;
        EndDate = endDate;
        Renewable = renewable;
        _productDurations = new List<ProductDuration>();
    }


    public string Title { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    public double Coefficient { get; set; }
    public string? StartDate { get; set; }
    public string? EndDate { get; set; }
    public bool Renewable { get; set; }

    public virtual IEnumerable<ProductDuration> ProductDurations => _productDurations.AsReadOnly();
}
