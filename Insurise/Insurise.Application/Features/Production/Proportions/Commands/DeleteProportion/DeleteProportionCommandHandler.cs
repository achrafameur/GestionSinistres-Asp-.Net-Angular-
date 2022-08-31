using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Production.Proportions.Commands.DeleteProportion;

public class DeleteProportionCommandHandler : IRequestHandler<DeleteProportionCommand>
{
    private readonly IRepository<Proportion> _proportionRepository;

    public DeleteProportionCommandHandler(IRepository<Proportion> proportionRepository)
    {
        _proportionRepository = proportionRepository;
    }

    public async Task<Unit> Handle(DeleteProportionCommand request, CancellationToken cancellationToken)
    {
        var proportionToDelete = await _proportionRepository.GetByIdAsync(request.ProportionId, cancellationToken);
        if (proportionToDelete == null) throw new ProportionNotFoundException(request.ProportionId);
        await _proportionRepository.DeleteAsync(proportionToDelete, cancellationToken);
        return Unit.Value;
    }
}