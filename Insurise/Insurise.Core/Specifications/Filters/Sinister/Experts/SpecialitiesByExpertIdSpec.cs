using Ardalis.Specification;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.Experts
{
    public class SpecialitiesByExpertIdSpec : Specification<Expert>, ISingleResultSpecification
    {
        public SpecialitiesByExpertIdSpec(int expertid) => _ = Query.Where(x => x.Id == expertid && !x.IsDeleted)
               .Include(x => x.ExpertSpecialities).ThenInclude(x => x.ChainElement)
               .EnableCache(nameof(SpecialitiesByExpertIdSpec), expertid)
               .OrderBy(x => x.Code);
    }
}