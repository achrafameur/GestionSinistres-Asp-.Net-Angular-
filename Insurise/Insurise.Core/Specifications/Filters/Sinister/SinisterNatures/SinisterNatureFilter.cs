using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.SinisterNatures
{
    public class SinisterNatureFilter :  BaseFilter
    {
        public int SinisterNatureId { get; set; }
        public string Title { get; set; }
        public int BranchId { get; set; }
    }
}
