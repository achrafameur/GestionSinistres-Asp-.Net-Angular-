using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;

public class GetAvgCostDetailQuery : IRequest<AvgCostDto>
{
    public GetAvgCostDetailQuery(int avgCostId)
    {
        AvgCostId = avgCostId;
    }

    public int AvgCostId { get; }
}