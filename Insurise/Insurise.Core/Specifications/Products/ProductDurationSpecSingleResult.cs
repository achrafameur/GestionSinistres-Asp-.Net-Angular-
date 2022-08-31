using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using System.Linq.Expressions;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Core.Specifications.Products;

public class ProductDurationSpecSingleResult : Specification<ProductDuration>, ISingleResultSpecification
{
 
    public ProductDurationSpecSingleResult(ProductDurationFilter filter)
    {
        Query.OrderBy(x => x.CreatedDate);
        if (filter.LoadChildren)
            foreach (var child in filter.Children) {
                Query.Include(child.ToString());
            }
     
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));


        if (filter.Id is > 0)
            Query.Where(x => x.Id == filter.Id);

        if (filter.ProductId is > 0)
            Query.Where(x => x.ProductId == filter.ProductId);

        if (filter.DurationId is > 0)
            Query.Where(x => x.DurationId == filter.DurationId);


        Query.Where(x => !x.IsDeleted);
        //Query.AsNoTracking();
    }
}
