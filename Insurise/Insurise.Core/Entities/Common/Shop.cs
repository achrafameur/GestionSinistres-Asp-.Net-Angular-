using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Shop : BaseEntity<int>
{

    private readonly List<ProductShop> _productShops; 
    public virtual IEnumerable<ProductShop> ProductShops => _productShops.AsReadOnly();
    public Shop(string title, ShopType type, string code, string description, int? departmentId)
    {
        Title = title;
        Type = type;
        Code = code;
        Description = description;
        DepartmentId = departmentId;
        _productShops = new List<ProductShop>();
    }

    public string Title { get; set; }
    public ShopType Type { get; set; }
    public string Code { get; set; }
    public string Description { get; set; } 
    public int? DepartmentId { get; set; } 
    public virtual Department Department { get; set; }
 
}
