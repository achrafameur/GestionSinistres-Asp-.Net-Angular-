using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Commands.AddAvgCost;

public class CreateSinisterNatureAverageCostCommand : IRequest<int>
{
    public CreateSinisterNatureAverageCostCommand(int sinisterNatureId, decimal averageCost, DateTime dateStart,
        DateTime dateEnd)
    {
        SinisterNatureId = sinisterNatureId;
        AverageCost = averageCost;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }

    public int SinisterNatureId { get; set; }
    public decimal AverageCost { get; set; }
    public DateTime DateStart { get; set; }
    public DateTime DateEnd { get; set; }
}