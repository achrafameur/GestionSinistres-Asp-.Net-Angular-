

using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class WarrantyTax : BaseEntity<int>
{
   
    public int Rank { get; set; }
    public string? Description { get; set; }
    public int WarrantyId { get; set; }
    public Warranty Warranty { get; set; }
    public int TaxId { get; set; }
    public Tax Tax { get; set; }
}