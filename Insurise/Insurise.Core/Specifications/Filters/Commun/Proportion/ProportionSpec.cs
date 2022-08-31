using Ardalis.Specification;

namespace Insurise.Core.Specifications.Filters.Commun.Proportion;

public class ProportionSpec : Specification<Entities.Common.Proportion>
{
    public ProportionSpec(ProportionFilter filter)
    {
        Query.OrderBy(x => x.Title)
            .ThenByDescending(x => x.Occurence);

        if (filter.LoadChildren)
            foreach (var child in filter.Children)
                Query.Include(child);
        if (filter.IsPagingEnabled)
            Query.Skip(PaginationHelper.CalculateSkip(filter))
                .Take(PaginationHelper.CalculateTake(filter));
         

        if (!string.IsNullOrEmpty(filter.Title))
            Query.Where(x => x.Title == filter.Title);

    
         
        Query.Where(x => !x.IsDeleted);
         
    }
}
