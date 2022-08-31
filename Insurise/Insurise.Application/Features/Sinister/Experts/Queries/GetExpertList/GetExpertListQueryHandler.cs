using AutoMapper;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertList;

public class GetExpertListQueryHandler : IRequestHandler<GetExpertListQuery, List<ExpertDto>>
{
    private readonly IRepository<Expert> _expertRepository;
    private readonly IMapper _mapper;

    public GetExpertListQueryHandler(IMapper mapper, IRepository<Expert> expertRepository)
    {
        _mapper = mapper;
        _expertRepository = expertRepository;
    }

    public async Task<List<ExpertDto>> Handle(GetExpertListQuery request, CancellationToken cancellationToken)
    {
        var allExperts = await _expertRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<ExpertDto>>(allExperts);
    }
}