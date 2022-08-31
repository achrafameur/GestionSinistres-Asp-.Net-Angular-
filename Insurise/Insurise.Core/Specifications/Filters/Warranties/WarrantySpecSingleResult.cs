using Ardalis.Specification;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class WarrantySpecSingleResult : Specification<Warranty>, ISingleResultSpecification
    {
        public static Expression<Func<Warranty, IEnumerable<Warranty>>> MyIncludeWarrantyFeature
        {
            get { return e => (IEnumerable<Warranty>)e.WarrantyFeatures.Where(x => !x.IsDeleted); }
        }
        public WarrantySpecSingleResult(WarrantyFilter filter)
        {
            Query.OrderBy(x => x.Title);

            if (filter.LoadChildren)
            {
                foreach (var child in filter.Children)
                {
                    if (child == "WarrantyFeaturesNotDeleted")
                        Query.Include(e => e.WarrantyFeatures.Where(x => !x.IsDeleted));
                    else if (child == "WarrantyTaxesNotDeleted")
                        Query.Include(e => e.WarrantyTaxes.Where(x => !x.IsDeleted));
                    else if (child == "WarrantyCommissionsNotDeleted")
                        Query.Include(e => e.WarrantyCommissions.Where(x => !x.IsDeleted));
                    else Query.Include(child.ToString());
                }
            }
            if (filter.IsPagingEnabled)
                Query.Skip(PaginationHelper.CalculateSkip(filter)).Take(PaginationHelper.CalculateTake(filter));
            if (filter.WarrantyId is > 0)
                Query.Where(x => x.Id == filter.WarrantyId);

          /*  if (filter.Features is not null)
                Query.Where(x => x.WarrantyFeatures == filter.Features);
*/
            if (!string.IsNullOrEmpty(filter.Title))
                Query.Where(x => x.Title == filter.Title);

            Query.Where(x => !x.IsDeleted);

        }
    }
}
