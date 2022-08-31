using MediatR;

namespace Insurise.Application.Features.Common.Natures.Commands.DeleteNature;

public class DeleteNatureCommand : IRequest
{
    public DeleteNatureCommand(int natureId)
    {
        NatureId = natureId;
    }

    public int NatureId { get; set; }
}