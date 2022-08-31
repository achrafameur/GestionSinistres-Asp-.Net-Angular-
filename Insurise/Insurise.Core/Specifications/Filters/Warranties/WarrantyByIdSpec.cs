using Ardalis.Specification;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class WarrantyByIdSpec : Specification<Warranty>, ISingleResultSpecification
    {
        public WarrantyByIdSpec(int warrantyId)
        { 
        _ = Query.Where(x => x.Id == warrantyId && !x.IsDeleted)
              /*  .Include(x => x.WarrantyFeatures)*/
                .EnableCache(nameof(WarrantyByIdSpec), warrantyId)
                .OrderBy(x => x.Title);
        

        }
    }
}

