using Ardalis.Specification;
using Insurise.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.features
{
    public class FeatureByIdSpec : Specification<Feature>, ISingleResultSpecification
    {
        public FeatureByIdSpec(int featureId) => _ = Query.Where(x => x.Id == featureId && !x.IsDeleted)
                .Include(x => x.Nature)
                 .Include(x => x.Chain)
                .EnableCache(nameof(FeatureByIdSpec), featureId)
                .OrderBy(x => x.Title);
        
    }
}
