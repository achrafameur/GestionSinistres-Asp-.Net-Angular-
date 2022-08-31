using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class ChainElement : BaseEntity<int>
{
    public ChainElement(string title)
    {
        Title = title;
    }

    public string Title { get; set; }
    public int? ChainId { get; set; }
    public Chain Chain { get; set; }

    public List<ExpertSpeciality> ExpertSpecialities { get; set; }
    public List<SinisterNatureSpeciality> SinisterNaturesSpecialities { get; set; }
}