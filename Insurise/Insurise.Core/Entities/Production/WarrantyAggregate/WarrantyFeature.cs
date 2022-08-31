using Insurise.Core.Entities.Common; 
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class WarrantyFeature : BaseEntity<int>
{
  

    public bool Mandatory { get; set; }
    public int Rank { get; set; }
    public int WarrantyId { get; set; }
    public Warranty Warranty { get; set; }
    public int FeatureId { get; set; }
    public Feature Feature { get; set; }
}