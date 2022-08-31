using InsuriseDTO;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertSpecialities;

public class GetExpertSpecialitiesQuery : IRequest<List<GetExpertSpecialityDto>>
{
    public GetExpertSpecialitiesQuery(int expertId)
    {
        ExpertId = expertId;
    }

    public int ExpertId { get; }
}
