using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Branch : BaseEntity<int>
{
    private readonly List<Product> _products;
    private readonly List<Branch> _children;
    private readonly List<SinisterNature> _sinisterNatures;

    public Branch(string title, string description, int? parentId=null)
    {
        Title = title;
        Description = description;
        ParentId = parentId.HasValue?parentId.Value:null;
        _products = new List<Product>();
        _children = new List<Branch>();
        _sinisterNatures = new List<SinisterNature>();
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int? ParentId { get; private set; }
    public Branch? BranchParent { get; set; }

    public IEnumerable<SinisterNature> SinisterNatures => _sinisterNatures.AsReadOnly();
    public IEnumerable<Product> Products => _products.AsReadOnly();
    public IEnumerable<Branch> Children => _children.AsReadOnly();
}
