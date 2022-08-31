using Insurise.Core.Entities.Common;
using Insurise.SharedKernel;

namespace Insurise.Core.Entities.Sinister.SinisterAggregate;

public class Status : BaseEntity<int>
{
    public Status(string title, string symbol, int itemId)
    {
        Title = title;
        Symbol = symbol;
        ItemId = itemId;
    }

    public string Title { get; set; }
    public string Symbol { get; set; }
    public int ItemId { get; set; }
    public Item Item { get; set; }
}