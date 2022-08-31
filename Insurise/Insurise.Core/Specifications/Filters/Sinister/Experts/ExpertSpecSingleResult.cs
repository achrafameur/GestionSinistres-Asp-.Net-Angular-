using Ardalis.Specification;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.Experts
{
    public class ExpertSpecSingleResult : Specification<Expert>, ISingleResultSpecification
    {
        public ExpertSpecSingleResult(ExpertFilter filter)
        {
            Query.OrderBy(x => x.FName);

            if (filter.LoadChildren)
            {
                foreach (var child in filter.Children)
                {
                    Query.Include(child.ToString());
                }
            }

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));

            if (filter.ExpertId is > 0)
                Query.Where(x => x.Id == filter.ExpertId);

            if (!string.IsNullOrEmpty(filter.FName))
                Query.Where(x => x.FName == filter.FName);

            Query.Where(x => !x.IsDeleted);
        }

    }
}
