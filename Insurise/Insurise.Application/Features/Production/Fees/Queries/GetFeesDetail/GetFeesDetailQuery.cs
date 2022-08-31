using MediatR;

namespace Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;

public class GetFeesDetailQuery : IRequest<FeesDto>
{
    public GetFeesDetailQuery(int id)
    {
        feesId = id;
    }

    public int feesId { get; }
}