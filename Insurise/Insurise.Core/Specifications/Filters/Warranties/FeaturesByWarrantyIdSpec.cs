using Ardalis.Specification;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class FeaturesByWarrantyIdSpec : Specification<Warranty>, ISingleResultSpecification
    {
        public FeaturesByWarrantyIdSpec(int warrantyId) {  _ = Query.Where(x => x.Id == warrantyId && !x.IsDeleted)
                  .Include(x => x.WarrantyFeatures).ThenInclude(x => x.Feature)
                  .EnableCache(nameof(FeaturesByWarrantyIdSpec), warrantyId)
                  .OrderBy(x => x.Title);
    }
    }
}
