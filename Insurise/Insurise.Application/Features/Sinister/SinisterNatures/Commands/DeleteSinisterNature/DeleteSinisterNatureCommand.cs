using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.DeleteSinisterNature;

public class DeleteSinisterNatureCommand : IRequest
{
    public DeleteSinisterNatureCommand(int sinisterNatureId)
    {
        SinisterNatureId = sinisterNatureId;
    }

    public int SinisterNatureId { get; set; }
}