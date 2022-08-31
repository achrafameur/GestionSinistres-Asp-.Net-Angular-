using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Sinister.SinisterNatureAverageCosts
{
    public class SinisterNatureAverageCostsFilter : BaseFilter
    {

        public int AvgCostId { get; set; }
        /*public string Title { get; set; }*/
        public int SinisterNatureId { get; set; }

    }
}
