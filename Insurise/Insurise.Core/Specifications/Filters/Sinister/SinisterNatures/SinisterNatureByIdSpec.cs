using Ardalis.Specification;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.SinisterNatures
{
    public class SinisterNatureByIdSpec : Specification<SinisterNature>, ISingleResultSpecification
    {
        public SinisterNatureByIdSpec(int sinisternatureid) => _ = Query.Where(x => x.Id == sinisternatureid && !x.IsDeleted)
               .Include(x => x.Branch)
               .EnableCache(nameof(SinisterNatureByIdSpec), sinisternatureid)
               .OrderBy(x => x.Title);
    }
}
