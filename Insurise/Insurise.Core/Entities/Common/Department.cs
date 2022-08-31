using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Department : BaseEntity<int>
{

    private readonly List<Shop> _DepartmentShops;

    public Department(string title, string symbol, string description)
    {
        Title = title;
        Symbol = symbol;
        Description = description;
    }

    public virtual IEnumerable<Shop>  DepartmentShops => _DepartmentShops.AsReadOnly();
  

    public string Title { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; } 
}
