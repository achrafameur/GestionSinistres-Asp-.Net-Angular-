using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Core.Specifications.Filters.Commun.features
{
    public class FeatureFilter : BaseFilter
    {
        public int FeatureId { get; set; }
        public string Title { get; set; }
        public int  NatureId { get; set; }
        public int ChainId { get; set; }
    }
}
