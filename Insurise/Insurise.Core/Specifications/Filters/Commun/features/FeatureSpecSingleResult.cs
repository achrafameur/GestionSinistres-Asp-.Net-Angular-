using Ardalis.Specification;
using Insurise.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.features
{
    public class FeatureSpecSingleResult : Specification<Feature>, ISingleResultSpecification
    {
        public FeatureSpecSingleResult(FeatureFilter filter)
        {
            Query.OrderBy(x => x.Title);
                

            if (filter.LoadChildren)
            {
                foreach (var child in filter.Children)
                {
                    if (child == "FeatureItemsNotDeleted")
                        Query.Include(e => e.FeatureItems.Where(x => !x.IsDeleted));
                    else Query.Include(child.ToString());
                }
            }

            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));

            if (filter.FeatureId is > 0)
                Query.Where(x => x.Id == filter.FeatureId);

            if (!string.IsNullOrEmpty(filter.Title))
                Query.Where(x => x.Title == filter.Title);

          

            if (filter.ChainId is > 0)
                Query.Where(x => x.ChainId == filter.ChainId);
            if (filter.NatureId is > 0)
                Query.Where(x => x.NatureId == filter.NatureId);

            Query.Where(x => !x.IsDeleted);
        }
    }
}
   