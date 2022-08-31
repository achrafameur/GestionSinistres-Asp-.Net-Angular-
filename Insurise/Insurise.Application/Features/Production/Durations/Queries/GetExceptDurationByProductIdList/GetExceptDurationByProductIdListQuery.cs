using Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;
using MediatR;

namespace Insurise.Application.Features.Production.Durations.Queries.GetExceptDurationByProductIdList;

public class GetExceptDurationByProductIdListQuery : IRequest<List<DurationDetailDto>>
{ 
    public GetExceptDurationByProductIdListQuery(int? productId) => ProductId = productId;

    public int? ProductId { get; }
}
