using Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;
using MediatR;

namespace Insurise.Application.Features.Common.Status.Queries.GetStatusList;

public class GetStatusListQuery : IRequest<List<StatusDto>>
{
}