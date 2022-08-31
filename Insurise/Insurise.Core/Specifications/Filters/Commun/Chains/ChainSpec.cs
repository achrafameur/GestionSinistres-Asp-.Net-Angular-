using Ardalis.Specification;
using Insurise.Core.Entities.Common;

namespace Insurise.Core.Specifications.Filters.Commun.Chains;

public class ChainSpec : Specification<Chain>
{
    public ChainSpec(ChainFilter filter)
    {
        Query.OrderBy(x => x.Title);

        if (filter.LoadChildren)
            foreach (var child in filter.Children)
                Query.Include(child.ToString());

        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));

        if (filter.ChainId is > 0)
            Query.Where(x => x.Id == filter.ChainId);

        if (!string.IsNullOrEmpty(filter.Title))
            Query.Where(x => x.Title == filter.Title);

        Query.Where(x => !x.IsDeleted);
    }
}