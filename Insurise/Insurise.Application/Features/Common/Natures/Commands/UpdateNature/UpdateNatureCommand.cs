using MediatR;

namespace Insurise.Application.Features.Common.Natures.Commands.UpdateNature;

public class UpdateNatureCommand : IRequest
{
    public UpdateNatureCommand(int natureId, string title, bool isList)
    {
        this.natureId = natureId;
        this.title = title;
        this.isList = isList;
    }

    public int natureId { get; set; }
    public string title { get; set; }
    public bool isList { get; set; }
}