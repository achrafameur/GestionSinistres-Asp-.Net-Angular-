namespace Insurise.Core.Specifications.Filters.Product;

public class ProductDurationFilter : BaseFilter
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int DurationId { get; set; }
    public string Actif { get; set; }
}
