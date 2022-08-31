using Ardalis.Specification;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class TaxesByWarrantyIdSpec : Specification<Warranty>, ISingleResultSpecification
    {
        public TaxesByWarrantyIdSpec(int warrantyId) {
            _ = Query.Where(x => x.Id == warrantyId && !x.IsDeleted)
                  .Include(x => x.WarrantyTaxes).ThenInclude(x => x.Tax)
                  .EnableCache(nameof(TaxesByWarrantyIdSpec), warrantyId)
                  .OrderBy(x => x.Title);
        }
    }
}
