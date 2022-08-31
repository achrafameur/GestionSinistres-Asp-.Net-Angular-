using MediatR;

namespace Insurise.Application.Features.Common.Items.Commands.CreateItem;

public class CreateItemCommand : IRequest<int>
{
    public CreateItemCommand(string title)
    {
        Title = title;
    }

    public string Title { get; set; }

    public override string ToString()
    {
        return $"Item name: {Title}; Created on:{DateTime.Now}";
    }
}