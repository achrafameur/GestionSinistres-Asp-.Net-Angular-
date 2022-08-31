using Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;
using MediatR;

namespace Insurise.Application.Features.Common.Natures.Queries.GetNaturesList;

public class GetNaturesListQuery : IRequest<List<NatureDto>>
{
}