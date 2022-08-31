using Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;
using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersList;

public class GetTiersListQuery : IRequest<List<TiersDto>>
{
}