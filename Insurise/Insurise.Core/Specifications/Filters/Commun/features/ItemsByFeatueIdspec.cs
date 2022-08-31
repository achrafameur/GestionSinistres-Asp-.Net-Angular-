using Ardalis.Specification;
using Insurise.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.features
{
    public class ItemsByFeatueIdspec : Specification<Feature>, ISingleResultSpecification
    {
        public ItemsByFeatueIdspec(int featureId)
        {   _ = Query.Where(x => x.Id == featureId && !x.IsDeleted)
                 .Include(x => x.FeatureItems).ThenInclude(x => x.Item)
                 .EnableCache(nameof(ItemsByFeatueIdspec), featureId)
                 .OrderBy(x => x.Title);
    }
    }
}
