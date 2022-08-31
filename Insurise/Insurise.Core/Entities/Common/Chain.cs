using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Chain : BaseEntity<int>
{
    private readonly List<ChainElement> _elements = new();
    public virtual IEnumerable<ChainElement> Elements => _elements.AsReadOnly();

    public Chain(string title)
    {
        Title = title;
    }

    public string Title { get; set; }


    public void AddChainElement(List<ChainElement> chainElements)
    {
        _elements.AddRange(chainElements);
    }
}