using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureFeatures;

public class GetSinisterNatureFeaturesQuery : IRequest<List<GetSinisterNatureFeaturesDto>>
{
    public GetSinisterNatureFeaturesQuery(int sinisterNatureId)
    {
        SinisterNatureId = sinisterNatureId;
    }

    public int SinisterNatureId { get; }
}