using Ardalis.Specification;
using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Core.Specifications.Products;

public class ProductDurationSpec : Specification<ProductDuration>
{
    public ProductDurationSpec(ProductDurationFilter filter)
    {
        Query.OrderBy(x => x.Product.Title)
            .ThenByDescending(x => x.Product.Code);

        if (filter.LoadChildren)
            foreach (var child in filter.Children)
                Query.Include(child);
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));

        if (filter.ProductId is > 0)
            Query.Where(x => x.ProductId == filter.ProductId);

        if (filter.DurationId is > 0)
            Query.Where(x => x.DurationId == filter.DurationId);



        Query.Where(x => !x.IsDeleted);
         
    }
}
