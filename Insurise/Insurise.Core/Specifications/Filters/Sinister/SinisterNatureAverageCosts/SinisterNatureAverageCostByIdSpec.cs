using Ardalis.Specification;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.SinisterNatureAverageCosts
{
    public class SinisterNatureAverageCostByIdSpec : Specification<SinisterNatureAverageCost>, ISingleResultSpecification
    {
        public SinisterNatureAverageCostByIdSpec(int sinisternatureid) => _ = Query.Where(x => x.Id == sinisternatureid && !x.IsDeleted)
               .Include(x => x.SinisterNature)
               .EnableCache(nameof(SinisterNatureAverageCostByIdSpec), sinisternatureid)
               .OrderBy(x => x.AverageCost);
    }
}
