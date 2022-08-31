using Insurise.Core.Entities.Production.ProductAggregate; 
using Insurise.Core.Events;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class Warranty : BaseEntity<int>
{
    // private readonly List<Condition> _conditions = new();

    public Warranty()
    {

    }
    public enum payementType
    {
        Prorata,
        Totale
    }

    public Warranty(string title , string? symbole, string? description, DateTime startDate,
        DateTime endDate,
        int defaultPeriod, bool isCommercialRate, payementType typeTarif)
    {
        Title = title; 
        Symbol = symbole;
        Description = description;
        StartDate = startDate;
        EndDate = endDate;
        DefaultPeriod = defaultPeriod;
        IsCommercialRate = isCommercialRate;
        TypeTarif = typeTarif;
    }

   
    public string Title { get; set; }
   
    public string? Symbol { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DefaultPeriod { get; set; }
    public bool IsCommercialRate { get; set; }
    public payementType TypeTarif { get; set; }
    public Rate Rate { get; set; }
    public Formula Formula { get; set; }
    public bool IsActive => StartDate <= DateTime.Now && EndDate >= DateTime.Now && CreatedDate <= DateTime.Now;

    private readonly List<WarrantyCommission> _warrantyCommissions = new List<WarrantyCommission>();
    public virtual IEnumerable<WarrantyCommission> WarrantyCommissions => _warrantyCommissions.AsReadOnly();
    private readonly List<WarrantyFeature> _warrantyFeatures = new List<WarrantyFeature>();
    public virtual IEnumerable<WarrantyFeature> WarrantyFeatures => _warrantyFeatures.AsReadOnly();

    public ICollection<ProductWarranty>? ProductWarranties { get; set; } = new List<ProductWarranty>();
    public readonly List<WarrantyTax> _warrantyTaxes = new List<WarrantyTax>();
    public virtual IEnumerable<WarrantyTax> WarrantyTaxes => _warrantyTaxes.AsReadOnly();



    public void AddWarrantyFeatures(List<WarrantyFeature> warrantyFeatures)
    {
        _warrantyFeatures.AddRange(warrantyFeatures);
        foreach (var warrantyFeature in warrantyFeatures)
        {
            var newFeatureAddedEvent = new WarrantyFeaturesChosenEvent(this, warrantyFeature.Feature);
            Events.Add(newFeatureAddedEvent);
        }
    }
    public void RemoveWarrantyFeatures(List<WarrantyFeature> warrantyFeatures)
    {
        foreach (var warrantyFeature in warrantyFeatures)
        {
            warrantyFeature.IsDeleted = true;
            warrantyFeature.Rank = 0;
        }
    }
    public void ReorderWarrantyFeatures()
    {
        int rank = 1;
        foreach (var warrantyFeature in _warrantyFeatures.Where(x => !x.IsDeleted))
        {
            warrantyFeature.Rank = rank;
            rank++;
        }
    }

    public void AddWarrantyTaxes(List<WarrantyTax> warrantyTaxes)
    {
        _warrantyTaxes.AddRange(warrantyTaxes);
        foreach (var warrantyTaxe in warrantyTaxes)
        {
            var newTaxAddedEvent = new WarrantyTaxesChoseEvent(warrantyTaxe.Tax, this);
            Events.Add(newTaxAddedEvent);
        }
    }
    public void RemoveWarrantyTaxes(List<WarrantyTax> warrantyTaxes)
    {
        foreach (var warrantyTaxe in warrantyTaxes)
        {
            warrantyTaxe.IsDeleted = true;
            warrantyTaxe.Rank = 0;
        }
    }
    public void ReorderWarrantyTaxes()
    {
        int rank = 1;
        foreach (var warrantyTaxe in _warrantyTaxes.Where(x => !x.IsDeleted))
        {
            warrantyTaxe.Rank = rank;
            rank++;
        }
    }



    public void AddWarrantyCommissions(List<WarrantyCommission> warrantyCommissions)
    {
        _warrantyCommissions.AddRange(warrantyCommissions);
        foreach (var warrantyCommission in warrantyCommissions)
        {
            var newCommissionAddedEvent = new WarrantyCommissionsChoseEvent(warrantyCommission.Commission, this);
            Events.Add(newCommissionAddedEvent);
        }
    }
    public void RemoveWarrantyCommissions(List<WarrantyCommission> warrantyCommissions)
    {
        foreach (var warrantyCommission in warrantyCommissions)
        {
            warrantyCommission.IsDeleted = true;
            warrantyCommission.Rank = 0;

        }
    }
    public void ReorderWarrantyCommissions()
    {
        int rank = 1;
        foreach (var warrantyCommission in _warrantyCommissions.Where(x => !x.IsDeleted))
        {
            warrantyCommission.Rank = rank;
            rank++;
        }
    }




    /*  public Pricing Pricing { get; set; }
      public IEnumerable<Condition> Conditions => _conditions.AsReadOnly();

      public void AddCondition(string title, string description)
      {
          var condition = new Condition(title, description);
          _conditions.Add(condition);
          Events.Add(new WarrantyUpdatedEvent(this));
      }*/
}
