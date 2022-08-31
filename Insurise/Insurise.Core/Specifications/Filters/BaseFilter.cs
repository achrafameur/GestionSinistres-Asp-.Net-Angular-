namespace Insurise.Core.Specifications.Filters;

public class BaseFilter
{
    public bool LoadChildren { get; set; }
    public List<string>? Children { get; set; }
    public bool IsPagingEnabled { get; set; }

    public int Page { get; set; }
    public int PageSize { get; set; }
}
