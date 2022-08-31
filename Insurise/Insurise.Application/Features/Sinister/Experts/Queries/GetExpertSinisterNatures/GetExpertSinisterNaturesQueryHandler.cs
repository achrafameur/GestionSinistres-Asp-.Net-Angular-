using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.Experts;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertSinisterNatures;

public class GetExpertSinisterNaturesQueryHandler : IRequestHandler<GetExpertSinisterNaturesQuery, List<GetExpertSinisterNaturesDto>>
{
    private readonly IRepository<Expert> _expertSinisterNatureRepository;
    private readonly IMapper _mapper;

    public GetExpertSinisterNaturesQueryHandler(IMapper mapper, IRepository<Expert> expertSinisterNatureRepository)
    {
        _mapper = mapper;
        _expertSinisterNatureRepository = expertSinisterNatureRepository;
    }

    public async Task<List<GetExpertSinisterNaturesDto>> Handle(GetExpertSinisterNaturesQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new ExpertFilter
        {
            ExpertId = request.ExpertId,
            LoadChildren = true,
            Children = new List<string> { "ExpertSinisterNatures", "ExpertSinisterNatures.SinisterNature" },
            IsPagingEnabled = true
        };

        var sinisterNaturesByExpertIdSpec = new ExpertSpecSingleResult(filter);
        var sinisterNaturesPerExpert = await _expertSinisterNatureRepository.GetBySpecAsync(sinisterNaturesByExpertIdSpec);
        return _mapper.Map<List<GetExpertSinisterNaturesDto>>(
            sinisterNaturesPerExpert?.ExpertSinisterNatures.OrderBy(x => x.Expert));
    }
}