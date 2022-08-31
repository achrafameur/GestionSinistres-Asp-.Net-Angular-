using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Commands.UpdateAvgCost;

public class UpdateSinisterNatureAverageCostCommand : IRequest
{
    public UpdateSinisterNatureAverageCostCommand(int avgCostId, int sinisterNatureId, decimal averageCost,DateTime dateStart, DateTime dateEnd)
    {
        AvgCostId = avgCostId;
        SinisterNatureId = sinisterNatureId;
        AverageCost = averageCost;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }

    public int AvgCostId { get; set; }
    public int SinisterNatureId { get; set; }
    public decimal AverageCost { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}