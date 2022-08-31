using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertNatures;

public class GetExpertNaturesQuery : IRequest<List<GetExpertNaturesDto>>
{
    public GetExpertNaturesQuery(int expertId)
    {
        ExpertId = expertId;
    }

    public int ExpertId { get; }
}