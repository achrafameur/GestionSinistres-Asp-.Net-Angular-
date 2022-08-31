using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertDetail;

public class GetExpertDetailQueryHandler : IRequestHandler<GetExpertDetailQuery, ExpertDto>
{
    private readonly IRepository<Expert> _expertRepository;
    private readonly IMapper _mapper;

    public GetExpertDetailQueryHandler(IMapper mapper, IRepository<Expert> expertRepository)
    {
        _mapper = mapper;
        _expertRepository = expertRepository;
    }

    public async Task<ExpertDto> Handle(GetExpertDetailQuery request, CancellationToken cancellationToken)
    {
        var expert = await _expertRepository.GetByIdAsync(request.ExpertId, cancellationToken);
        var returnedexpert = _mapper.Map<ExpertDto>(expert);

        return returnedexpert;
    }
}