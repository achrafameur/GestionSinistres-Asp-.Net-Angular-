using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Events;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Feature : BaseEntity<int>
{
  
    private readonly List<WarrantyFeature> _warranties;
    private readonly List<SinisterNatureFeature> _sinisterNaturesFeatures;

   

    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Symbol { get; set; }
    public int? Fixed { get; set; }
    public float? Minimum { get; set; }
    public float? Maximum { get; set; }
    public bool Alterable { get; set; }
    public bool IsPrincipal { get; set; }
    
    public int? RankShow { get; set; }
    public int? ChainId { get; set; }
    public Chain? Chain { get; set; }
    public int NatureId { get; set; }
    public Nature Nature { get; set; }

    private readonly List<FeatureItem> _featureItems = new List<FeatureItem>();
    public virtual IEnumerable<FeatureItem> FeatureItems => _featureItems.AsReadOnly();
   
    public virtual IReadOnlyCollection<WarrantyFeature>? Warranties => _warranties.AsReadOnly();
    public virtual IEnumerable<SinisterNatureFeature> SinisterNaturesFeatures => _sinisterNaturesFeatures.AsReadOnly();

  

    public Feature(string title, string? description, string? symbol, int? @fixed, float? minimum, float? maximum, bool alterable, bool isPrincipal, int? rankShow, int? chainId , int natureId)
    {
        Title = title;
        Description = description;
        Symbol = symbol;
        Fixed = @fixed;
        Minimum = minimum;
        Maximum = maximum;
        Alterable = alterable;
        IsPrincipal = isPrincipal;
        RankShow = rankShow;
        ChainId = chainId; 
        NatureId = natureId; 
        _warranties = new List<WarrantyFeature>();
        _sinisterNaturesFeatures = new List<SinisterNatureFeature>();
    }

  
    public void AddFeatureItems(List<FeatureItem> featureItems)
    {
        _featureItems.AddRange(featureItems);
        foreach (var featureItem in featureItems)
        {
            var newFeatureAddedEvent = new FeatureItemsChoseEvent(this, featureItem.Item);
            Events.Add(newFeatureAddedEvent);
        }
    }
    public void RemoveFeatureItems(List<FeatureItem> featureItems)
    {
        foreach (var featureItem in featureItems)
        {
            featureItem.IsDeleted = true;
            featureItem.Rank = 0;
            
        }
    }
    public void ReorderFeatureItems()
    {
        int rank = 1;
        foreach (var featureItem in _featureItems.Where(x => !x.IsDeleted))
        {
            featureItem.Rank = rank;
            rank++;
        }
    }
    internal void SetFeatureNature(Nature nature)
          => Nature = nature;
    internal void SetFeatureChain(Chain chain)
         => Chain = chain;
}