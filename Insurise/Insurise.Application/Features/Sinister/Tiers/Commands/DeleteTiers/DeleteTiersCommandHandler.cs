using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Commands.DeleteTiers;

public class DeleteTiersCommandHandler : IRequestHandler<DeleteTiersCommand>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> _tiersRepository;


    public DeleteTiersCommandHandler(IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> tiersRepository)
    {
        _tiersRepository = tiersRepository;
    }

    public async Task<Unit> Handle(DeleteTiersCommand request, CancellationToken cancellationToken)
    {
        var tiersToDelete = await _tiersRepository.GetByIdAsync(request.TiersId, cancellationToken);

        if (tiersToDelete == null) throw new TierNotFoundException(request.TiersId);

        await _tiersRepository.DeleteAsync(tiersToDelete, cancellationToken);

        return Unit.Value;
    }
}