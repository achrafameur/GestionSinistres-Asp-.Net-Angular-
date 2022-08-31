using MediatR;

namespace Insurise.Application.Features.Production.Tax.Queries.GetTaxList;

public class GetTaxListQuery : IRequest<List<TaxDto>>
{
}