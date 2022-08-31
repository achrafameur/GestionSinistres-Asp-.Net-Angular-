using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;

public class GetTiersDetailQuery : IRequest<TiersDto>
{
    public GetTiersDetailQuery(int tiersId)
    {
        TiersId = tiersId;
    }

    public int TiersId { get; }
}