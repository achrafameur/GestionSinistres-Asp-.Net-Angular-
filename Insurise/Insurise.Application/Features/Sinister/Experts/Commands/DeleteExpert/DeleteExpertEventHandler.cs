using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.DeleteExpert;

public class DeleteExpertEventHandler : IRequestHandler<DeleteExpertCommand>
{
    private readonly IRepository<Expert> _expertRepository;

    public DeleteExpertEventHandler(IRepository<Expert> expertRepository)
    {
        _expertRepository = expertRepository;
    }

    public async Task<Unit> Handle(DeleteExpertCommand request, CancellationToken cancellationToken)
    {
        var expertToDelete = await _expertRepository.GetByIdAsync(request.ExpertId, cancellationToken);

        if (expertToDelete == null) throw new ExpertNotFoundException(request.ExpertId);

        await _expertRepository.DeleteAsync(expertToDelete, cancellationToken);

        return Unit.Value;
    }
}