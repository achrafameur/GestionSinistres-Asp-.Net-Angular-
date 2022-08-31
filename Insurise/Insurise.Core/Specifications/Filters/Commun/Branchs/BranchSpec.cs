using Insurise.Core.Entities.Common;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.Branchs
{
    public class BranchSpec : Specification<Branch>
    {
        public BranchSpec(BranchFilter filter)
        {
           /* Query.OrderBy(x => x.Title);*/

            if (filter.LoadChildren)
            {
                foreach (var child in filter.Children)
                {
                    Query.Include(child.ToString());
                }
            }

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));

            if (filter.ParentId is > 0)
                Query.Where(x => x.Id == filter.ParentId);

          /*  if (!string.IsNullOrEmpty(filter.Title))
                Query.Where(x => x.Title == filter.Title);*/

            Query.Where(x => !x.IsDeleted);
        }
    }
}
