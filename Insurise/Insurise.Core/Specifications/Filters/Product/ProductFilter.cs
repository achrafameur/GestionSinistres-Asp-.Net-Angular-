namespace Insurise.Core.Specifications.Filters.Product;

public class ProductFilter : BaseFilter
{
    public int ProductId { get; set; }
    public string Title { get; set; }
    public string Code { get; set; }
    public int BranchId { get; set; }
}