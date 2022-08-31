using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Commands.DeleteTiers;

public class DeleteTiersCommand : IRequest
{
    public DeleteTiersCommand(int tiersId)
    {
        TiersId = tiersId;
    }

    public int TiersId { get; }
}