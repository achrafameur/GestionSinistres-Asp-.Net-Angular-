using MediatR;

namespace Insurise.Application.Features.Common.Status.Commands.AddStatus;

public class CreateStatusCommand : IRequest<int>
{
    public CreateStatusCommand(string title, string symbol, int itemId)
    {
        Title = title;
        Symbol = symbol;
        ItemId = itemId;
        CreationDate = DateTime.Now;
    }

    public string Title { get; }
    public string Symbol { get; set; }
    public DateTime CreationDate { get; set; }
    public int ItemId { get; set; }
}