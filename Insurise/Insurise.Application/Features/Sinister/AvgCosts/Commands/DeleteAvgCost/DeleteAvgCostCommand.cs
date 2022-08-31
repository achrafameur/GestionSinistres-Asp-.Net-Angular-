using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Commands.DeleteAvgCost;

public class DeleteAvgCostCommand : IRequest
{
    public DeleteAvgCostCommand(int avgCostId)
    {
        AvgCostId = avgCostId;
    }

    public int AvgCostId { get; }
}