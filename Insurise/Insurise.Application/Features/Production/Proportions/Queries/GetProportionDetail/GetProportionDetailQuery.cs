using Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;
using MediatR;

namespace Insurise.Application.Features.Production.Proportions.Queries.GetProportionDetail;

public class GetProportionDetailQuery : IRequest<ProportionDto>
{
    public GetProportionDetailQuery(int proportionId)
    {
        ProportionId = proportionId;
    }

    public int ProportionId { get; }
}