using Ardalis.Specification;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.Experts
{
    public class SinisterNaturesByExpertIdSpec : Specification<Expert>, ISingleResultSpecification
    {
        public SinisterNaturesByExpertIdSpec(int expertid) => _ = Query.Where(x => x.Id == expertid && !x.IsDeleted)
               .Include(x => x.ExpertSinisterNatures).ThenInclude(x => x.SinisterNature)
               .EnableCache(nameof(SinisterNaturesByExpertIdSpec), expertid)
               .OrderBy(x => x.Code);
    }
}