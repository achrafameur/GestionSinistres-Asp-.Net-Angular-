using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Common;

public class Nature : BaseEntity<int>
{
    private readonly List<ExpertNature> _expertNatures;

    public Nature(string title,bool isList)
    {
        Title = title; 
        IsList = isList;
    }

    public string Title { get; set; } 
    public bool IsList { get; set; }
   
}