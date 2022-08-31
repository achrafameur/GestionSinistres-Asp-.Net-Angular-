using Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;
using MediatR;

namespace Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostsList;

public class GetAvgCostsListQuery : IRequest<List<AvgCostDto>>
{
}