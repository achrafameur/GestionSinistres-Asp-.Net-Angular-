using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.Status
{
    public class StatusFilter : BaseFilter
    {
        public int StatusId { get; set; }
        public string Title { get; set; }
        public int ItemId { get; set; }
    }
}
