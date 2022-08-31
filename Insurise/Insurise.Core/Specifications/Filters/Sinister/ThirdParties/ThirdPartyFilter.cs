using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.ThirdParties
{
    public class ThirdPartyFilter : BaseFilter
    {

        public int TiersId { get; set; }
        public string Title { get; set; }
        public int TiersCompanyId { get; set; }
        
    }
}
