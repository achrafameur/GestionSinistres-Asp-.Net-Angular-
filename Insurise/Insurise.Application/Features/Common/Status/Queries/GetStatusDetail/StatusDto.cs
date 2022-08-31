namespace Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;

public class StatusDto
{
    public StatusDto(int statusId, string title, string symbol, int itemId, string item)
    {
        StatusId = statusId;
        Title = title;
        Symbol = symbol;
        ItemId = itemId;
        Item = item;
        CreationDate = DateTime.Now;
    }

    public int StatusId { get; set; }
    public string Title { get; }
    public string Symbol { get; set; }
    public DateTime CreationDate { get; set; }
    public int ItemId { get; set; }
    public string Item { get; set; }
}