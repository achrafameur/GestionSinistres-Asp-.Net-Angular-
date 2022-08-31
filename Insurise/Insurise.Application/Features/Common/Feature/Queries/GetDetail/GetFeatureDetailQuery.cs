using Insurise.Application.Features.Common.Feature.Queries.GetList;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Queries.GetDetail;

public class GetFeatureDetailQuery : IRequest<FeatureDto>
{
    public GetFeatureDetailQuery(int featureId)
    {
        FeatureId = featureId;
    }

    public int FeatureId { get; }
}