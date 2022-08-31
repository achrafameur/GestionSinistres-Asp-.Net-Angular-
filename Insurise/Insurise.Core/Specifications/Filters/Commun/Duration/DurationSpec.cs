using Ardalis.Specification;

namespace Insurise.Core.Specifications.Filters.Commun.Duration;

public class DurationSpec : Specification<Entities.Common.Duration>
{
    public DurationSpec(DurationFilter filter)
    {
        Query.OrderBy(x => x.Title)
            .ThenByDescending(x => x.Type);

        if (filter.LoadChildren)
            foreach (var child in filter.Children)
                Query.Include(child);
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));

        if (filter.DurationId is > 0)
            Query.Where(x => x.Id==filter.DurationId);

        if (filter.ProductId is > 0)
            Query.Where(x => !x.ProductDurations.Any(x=>x.ProductId == filter.ProductId) || ( !x.ProductDurations.Any(x => x.IsDeleted)));

        if (!string.IsNullOrEmpty(filter.Title))
            Query.Where(x => x.Title == filter.Title);

    
         
        Query.Where(x => !x.IsDeleted);
         
    }
}
