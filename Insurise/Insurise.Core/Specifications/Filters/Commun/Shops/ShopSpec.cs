using Ardalis.Specification;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Core.Specifications.Filters.Commun.Shops;

public class ShopSpec : Specification<Shop>
{
    public ShopSpec(ProductFilter filter)
    {
        Query.OrderBy(x => x.Title)
            .ThenByDescending(x => x.Code);

        if (filter.LoadChildren)
            foreach (var child in filter.Children)
                Query.Include(child);
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));

        //if (filter.ProductId is > 0)
        //    Query.Where(x => x.Id == filter.ProductId);

        if (!string.IsNullOrEmpty(filter.Title))
            Query.Where(x => x.Title == filter.Title);

        if (!string.IsNullOrEmpty(filter.Code))
            Query.Where(x => x.Code == filter.Code);
         
        Query.Where(x => !x.IsDeleted);
         
    }
}
