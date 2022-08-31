namespace Insurise.Application.Features.Common.Items.Queries.GetItemDetail;

public class ItemDto
{
    public ItemDto(int id, string title)
    {
        Id = id;
        Title = title;
    }

    public int Id { get; }
    public string Title { get; }
}