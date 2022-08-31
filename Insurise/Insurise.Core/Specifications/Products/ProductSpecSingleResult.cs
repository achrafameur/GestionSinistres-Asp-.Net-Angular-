using Ardalis.Specification;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using System.Linq.Expressions;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Core.Specifications.Products;

public class ProductSpecSingleResult : Specification<Product>, ISingleResultSpecification
{
    public static Expression<Func<Product, IEnumerable<Product>>> MyIncludeProductWarranties
    {
        get { return e => (IEnumerable<Product>)e.ProductWarranties.Where(x => !x.IsDeleted); }
    }
    public ProductSpecSingleResult(ProductFilter filter)
    {
        Query.OrderBy(x => x.Title)
            .ThenByDescending(x => x.Code); 
        if (filter.LoadChildren)
            foreach (var child in filter.Children) {
                if (child == "ProductWarrantiesNotDeleted")
                    Query.Include(e=>e.ProductWarranties.Where(x => !x.IsDeleted));
                else if (child == "ProductFeesNotDeleted")
                    Query.Include(e => e.ProductFees.Where(x => !x.IsDeleted));
                else if (child == "ProductShopsNotDeleted")
                    Query.Include(e => e.ProductShops.Where(x => !x.IsDeleted));
                else if (child == "ProductDurationsProportionsNotDeleted")
                    Query.Include(e => e.ProductDurations.Where(x => !x.IsDeleted)).ThenInclude(r=>r.Proportions.Where(y => !y.IsDeleted)); 
                else Query.Include(child.ToString());
            }
     
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));

        if (filter.ProductId is > 0)
            Query.Where(x => x.Id == filter.ProductId);

        if (!string.IsNullOrEmpty(filter.Title))
            Query.Where(x => x.Title == filter.Title);

        if (!string.IsNullOrEmpty(filter.Code))
            Query.Where(x => x.Code == filter.Code);

        if (filter.BranchId is > 0)
            Query.Where(x => x.BranchId == filter.BranchId);

        Query.Where(x => !x.IsDeleted); 
    }
}
