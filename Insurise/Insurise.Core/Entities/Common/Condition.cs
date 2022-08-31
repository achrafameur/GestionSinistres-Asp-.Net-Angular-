using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Condition : BaseEntity<int>
{
    public Condition(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public string Title { get; private set; }
    public string Description { get; private set; }
}