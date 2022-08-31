

using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Production.WarrantyAggregate;

public class WarrantyCommission :  BaseEntity<int>
{
    public string? Description { get; set; }
    public int Rank { get; set; }
    public int? CodeAgence { get; set; }
    public string? LibelleAgence { get; set; }
    public int WarrantyId { get; set; }
    public Warranty Warranty { get; set; }
    public int CommissionId { get; set; }
    public Commission Commission { get; set; }
}