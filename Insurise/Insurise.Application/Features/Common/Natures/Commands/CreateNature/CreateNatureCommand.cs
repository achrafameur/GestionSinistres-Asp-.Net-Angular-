using MediatR;

namespace Insurise.Application.Features.Common.Natures.Commands.CreateNature;

public class CreateNatureCommand : IRequest<int>
{
    public CreateNatureCommand(string title, bool isList)
    {
        Title = title;
        IsList = isList;
    }

    public string Title { get; set; }
    public bool IsList { get; set; }


    public override string ToString()
    {
        return $"Item name: {Title}; Created on:{DateTime.Now}";
    }
}