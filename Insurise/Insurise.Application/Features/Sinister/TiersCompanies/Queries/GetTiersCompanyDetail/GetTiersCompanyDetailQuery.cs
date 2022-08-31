using MediatR;

namespace Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompanyDetail;

public class GetTiersCompanyDetailQuery : IRequest<TiersCompanyDto>
{
    public GetTiersCompanyDetailQuery(int tiersCompanyId)
    {
        TiersCompanyId = tiersCompanyId;
    }

    public int TiersCompanyId { get; }
}