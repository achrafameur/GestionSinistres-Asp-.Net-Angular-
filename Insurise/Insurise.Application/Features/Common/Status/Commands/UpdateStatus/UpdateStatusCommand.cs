using MediatR;

namespace Insurise.Application.Features.Common.Status.Commands.UpdateStatus;

public class UpdateStatusCommand : IRequest
{
    public UpdateStatusCommand(int statusId, string title, string symbol, int itemId)
    {
        StatusId = statusId;
        Title = title;
        Symbol = symbol;
        ItemId = itemId;
        CreationDate = DateTime.Now;
    }

    public int StatusId { get; set; }
    public string Title { get; }
    public string Symbol { get; set; }
    public DateTime CreationDate { get; set; }
    public int ItemId { get; set; }
}