using Insurise.Application.Features.Common.Feature.Queries.GetList;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Queries.GetList;

public class GetFeatureListQuery : IRequest<List<FeatureDto>>
{
}