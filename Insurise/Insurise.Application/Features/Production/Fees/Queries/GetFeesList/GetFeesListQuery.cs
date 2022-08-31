using Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;
using MediatR;

namespace Insurise.Application.Features.Production.Fees.Queries.GetFeesList;

public class GetFeesListQuery : IRequest<List<FeesDto>>
{
}