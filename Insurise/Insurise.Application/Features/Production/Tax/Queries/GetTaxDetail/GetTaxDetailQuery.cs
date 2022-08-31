using Insurise.Application.Features.Production.Tax.Queries.GetTaxList;
using MediatR;

namespace Insurise.Application.Features.Production.Tax.Queries.GetTaxDetail;

public class GetTaxDetailQuery : IRequest<TaxDto>
{
    public GetTaxDetailQuery(int taxId)
    {
        TaxId = taxId;
    }

    public int TaxId { get; }
}