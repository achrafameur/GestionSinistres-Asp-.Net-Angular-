using Ardalis.Specification;
using Insurise.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.items
{
    public class ItemSpecSingleResult : Specification<Item>, ISingleResultSpecification
    {
        public ItemSpecSingleResult(ItemFilter filter)
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
            if (filter.ItemId is > 0)
                Query.Where(x => x.Id == filter.ItemId);

            /*  if (filter.Features is not null)
                  Query.Where(x => x.WarrantyFeatures == filter.Features);
  */
            if (!string.IsNullOrEmpty(filter.Title))
                Query.Where(x => x.Title == filter.Title);

            Query.Where(x => !x.IsDeleted);

        }
    }
}
