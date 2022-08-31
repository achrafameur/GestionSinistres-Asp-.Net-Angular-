using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Core.Specifications.Products;

public class ProductByIdSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByIdSpec(int productid)
    {
        _ = Query.Where(x => x.Id == productid && !x.IsDeleted)
            .Include(x => x.Branch)
            .EnableCache(nameof(ProductByIdSpec), productid)
            .OrderBy(x => x.Title);
    }
}