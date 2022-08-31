using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Core.Specifications.Products;

public class WarrantiesByProductIdSpec : Specification<Product>, ISingleResultSpecification
{
    public WarrantiesByProductIdSpec(int productid)
    {
        _ = Query.Where(x => x.Id == productid && !x.IsDeleted)
            .Include(x => x.ProductWarranties).ThenInclude(x => x.Warranty)
            .EnableCache(nameof(WarrantiesByProductIdSpec), productid)
            .OrderBy(x => x.Title);
    }
}