using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Events;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Item : BaseEntity<int>
{
    private readonly List<FeatureItem> _featureItems;
    public Item(string title)
    {
        Title = title;
        _featureItems = new List<FeatureItem>();
    }

    public string Title { get; set; }

    public List<Status> Status { get; set; }
    public  IReadOnlyCollection<FeatureItem>? FeatureItems => _featureItems.AsReadOnly();
   

} 