using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNaturesList;

public class GetSinisterNaturesListQuery : IRequest<List<SinisterNatureDto>>
{
}