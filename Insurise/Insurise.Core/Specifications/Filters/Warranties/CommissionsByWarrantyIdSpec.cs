using Ardalis.Specification;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class CommissionsByWarrantyIdSpec : Specification<Warranty>, ISingleResultSpecification
    {
        public CommissionsByWarrantyIdSpec(int warrantyId) {
            _ = Query.Where(x => x.Id == warrantyId && !x.IsDeleted)
                    .Include(x => x.WarrantyCommissions).ThenInclude(x => x.Commission)
                    .EnableCache(nameof(CommissionsByWarrantyIdSpec), warrantyId)
                    .OrderBy(x => x.Title);
        }
    }
}
