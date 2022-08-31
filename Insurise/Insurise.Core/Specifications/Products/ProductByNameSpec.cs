using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Core.Specifications.Products;

public class ProductByNameSpec : Specification<Product>, ISingleResultSpecification
{
    public ProductByNameSpec(string name)
    {
        Query.Where(x => x.Title == name && !x.IsDeleted)
            .OrderBy(x => x.Title)
            .ThenByDescending(x => x.Code);
    }
}