 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Warranties
{
    public class WarrantyFilter : BaseFilter
    {
        public int WarrantyId { get; set; }
        public string Title { get; set; }
       /* public List<WarrantyFeature> Features { get; set; }*/
    }
}
