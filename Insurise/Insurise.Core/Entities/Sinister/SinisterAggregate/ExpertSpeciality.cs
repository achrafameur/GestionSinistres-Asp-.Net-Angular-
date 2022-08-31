using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate
{
    public class ExpertSpeciality : BaseEntity<int>
    {
        public bool Mandatory { get; set; }
        public int ChainElementId { get; set; }
        public ChainElement? ChainElement { get; set; }
        public int ExpertId { get; set; }
        public Expert? Expert { get; set; }
    }
}
