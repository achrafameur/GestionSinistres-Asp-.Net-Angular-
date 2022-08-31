using MediatR;

namespace Insurise.Application.Features.Common.Items.Commands.UpdateItem;

public class UpdateItemCommand : IRequest
{
    public UpdateItemCommand(int itemId, string title)
    {
        ItemId = itemId;
        Title = title;
    }

    public int ItemId { get; }
    public string Title { get; }
}