using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.items
{
    public class ItemFilter : BaseFilter
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
    }
}
