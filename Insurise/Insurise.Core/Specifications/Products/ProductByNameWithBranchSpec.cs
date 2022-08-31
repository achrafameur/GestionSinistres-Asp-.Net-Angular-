using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Core.Specifications.Products;

public class ProductByNameWithBranchSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByNameWithBranchSpec(string name)
    {
        Query.Where(x => x.Title == name && !x.IsDeleted)
            .Include(x => x.Branch)
            .EnableCache(nameof(ProductByNameWithBranchSpec), name);
    }
}