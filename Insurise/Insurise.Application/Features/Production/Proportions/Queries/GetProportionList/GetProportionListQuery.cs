using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;

public class GetProportionListQuery : IRequest<List<ProportionDto>>
{
}