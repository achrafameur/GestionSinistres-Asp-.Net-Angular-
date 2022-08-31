using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Core.Specifications.Products;

public class ProductSpec : Specification<Product>
{
    public ProductSpec(ProductFilter filter)
    {
        Query.OrderBy(x => x.Title)
            .ThenByDescending(x => x.Code);

        if (filter.LoadChildren)
            foreach (var child in filter.Children)
                Query.Include(child.ToString());
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));

        if (filter.ProductId is > 0)
            Query.Where(x => x.Id == filter.ProductId);

        if (!string.IsNullOrEmpty(filter.Title))
            Query.Where(x => x.Title == filter.Title);

        if (!string.IsNullOrEmpty(filter.Code))
            Query.Where(x => x.Code == filter.Code);

        if (filter.BranchId is > 0)
            Query.Where(x => x.BranchId == filter.BranchId);

        Query.Where(x => !x.IsDeleted);

        //    if (!string.IsNullOrEmpty(filter.de))
        //Query.Search(x => x.BranchId, "%" + filter.BranchId + "%");
    }
}