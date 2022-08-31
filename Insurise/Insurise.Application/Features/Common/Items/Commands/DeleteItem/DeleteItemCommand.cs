using MediatR;

namespace Insurise.Application.Features.Common.Items.Commands.DeleteItem;

public class DeleteItemCommand : IRequest
{
    public DeleteItemCommand(int itemId)
    {
        ItemId = itemId;
    }

    public int ItemId { get; }
}