using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class FeatureItem : BaseEntity<int>
{

    public int Rank { get; set; }
    public int FeatureId { get; set; }
    public Feature Feature { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
}