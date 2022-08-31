using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureSpecialities;

public class GetSinisterNatureSpecialitiesQuery : IRequest<List<GetSinisterNatureSpecialitiesDto>>
{
    public GetSinisterNatureSpecialitiesQuery(int sinisterNatureId)
    {
        SinisterNatureId = sinisterNatureId;
    }

    public int SinisterNatureId { get; }
}