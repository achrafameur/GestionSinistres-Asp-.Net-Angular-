using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.Branchs
{
    public class BranchFilter : BaseFilter
    {
        public int BranchId { get; set; }
        public string Title { get; set; }
        public int ParentId { get; set; }
    }
}
