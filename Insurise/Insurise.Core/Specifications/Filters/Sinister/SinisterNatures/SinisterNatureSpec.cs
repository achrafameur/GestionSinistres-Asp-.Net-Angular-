using Ardalis.Specification;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.SinisterNatures
{
    public class SinisterNatureSpec : Specification<SinisterNature>
    {
        public SinisterNatureSpec(SinisterNatureFilter filter)
        {
            Query.OrderBy(x => x.Title);

            if (filter.LoadChildren)
            {
                foreach (var child in filter.Children)
                {
                    Query.Include(child.ToString());
                }
            }

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));

            if (filter.BranchId is > 0)
                Query.Where(x => x.Id == filter.BranchId);

            if (filter.SinisterNatureId is > 0)
                Query.Where(x => x.Id == filter.SinisterNatureId);

            if (!string.IsNullOrEmpty(filter.Title))
                Query.Where(x => x.Title == filter.Title);

            Query.Where(x => !x.IsDeleted);
        }
    }
}
