using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Type : BaseEntity<int>
{
    public Type(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }
}