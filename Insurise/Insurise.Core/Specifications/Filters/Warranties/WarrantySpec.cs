using Ardalis.Specification;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class WarrantySpec : Specification<Warranty>
    {
        public WarrantySpec(WarrantyFilter filter)
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
            if (filter.WarrantyId is > 0)
                Query.Where(x => x.Id == filter.WarrantyId);

          /*  if (filter.Features is not null)
                Query.Where(x => x.WarrantyFeatures == filter.Features);*/

            if (!string.IsNullOrEmpty(filter.Title))
                Query.Where(x => x.Title == filter.Title);

            Query.Where(x => !x.IsDeleted);
        }
    }

}