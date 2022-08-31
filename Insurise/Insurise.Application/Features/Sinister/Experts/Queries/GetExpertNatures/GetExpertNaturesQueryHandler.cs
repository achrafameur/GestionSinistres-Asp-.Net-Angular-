using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertNatures;

public class GetExpertNaturesQueryHandler : IRequestHandler<GetExpertNaturesQuery, List<GetExpertNaturesDto>>
{
    private readonly IRepository<ExpertNature> _expertNatureRepository;
    private readonly IMapper _mapper;

    public GetExpertNaturesQueryHandler(IMapper mapper, IRepository<ExpertNature> expertNatureRepository)
    {
        _mapper = mapper;
        _expertNatureRepository = expertNatureRepository;
    }

    public async Task<List<GetExpertNaturesDto>> Handle(GetExpertNaturesQuery request,
        CancellationToken cancellationToken)
    {
        var allNatures = await _expertNatureRepository.ListAsync(cancellationToken);
        var expertNatures = new List<int>();
        foreach (var sn in allNatures)
            if (sn.ExpertId == request.ExpertId)
                expertNatures.Add(sn.NatureId);
        return _mapper.Map<List<GetExpertNaturesDto>>(expertNatures);
    }
}