using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertDetail;

public class GetExpertDetailQuery : IRequest<ExpertDto>
{
    public GetExpertDetailQuery(int expertId)
    {
        ExpertId = expertId;
    }

    public int ExpertId { get; }
}