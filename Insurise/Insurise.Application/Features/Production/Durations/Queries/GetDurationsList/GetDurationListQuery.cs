using Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;
using MediatR;

namespace Insurise.Application.Features.Production.Durations.Queries.GetDurationsList;

public class GetDurationListQuery : IRequest<List<DurationDetailDto>>
{
}