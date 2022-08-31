using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Commands.DeleteAvgCost;

public class DeleteAvgCostCommandHandler : IRequestHandler<DeleteAvgCostCommand>
{
    private readonly IRepository<SinisterNatureAverageCost> _avgCostRepository;

    public DeleteAvgCostCommandHandler(IRepository<SinisterNatureAverageCost> avgCostRepository)
    {
        _avgCostRepository = avgCostRepository;
    }

    public async Task<Unit> Handle(DeleteAvgCostCommand request, CancellationToken cancellationToken)
    {
        var avgCostToDelete = await _avgCostRepository.GetByIdAsync(request.AvgCostId, cancellationToken);

        if (avgCostToDelete == null) throw new AverageCostNotFoundException(request.AvgCostId);

        await _avgCostRepository.DeleteAsync(avgCostToDelete, cancellationToken);

        return Unit.Value;
    }
}