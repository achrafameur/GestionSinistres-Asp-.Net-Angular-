using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.Experts
{
    public class ExpertFilter : BaseFilter
    {
        public int ExpertId { get; set; }
        public string FName { get; set; }
    }
}
