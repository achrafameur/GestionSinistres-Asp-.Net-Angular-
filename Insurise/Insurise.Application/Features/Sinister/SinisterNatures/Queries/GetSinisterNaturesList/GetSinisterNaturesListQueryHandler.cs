using AutoMapper;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatures;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNaturesList;

public class GetSinisterNaturesListQueryHandler : IRequestHandler<GetSinisterNaturesListQuery, List<SinisterNatureDto>>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public GetSinisterNaturesListQueryHandler(IMapper mapper, IRepository<SinisterNature> SinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = SinisterNatureRepository;
    }

    public async Task<List<SinisterNatureDto>> Handle(GetSinisterNaturesListQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new SinisterNatureFilter
        {
            LoadChildren = true,
            Children = new List<string> {"Branch"},
            IsPagingEnabled = false
        };
        var spec = new SinisterNatureSpec(filter);
        var allSinisterNatures = await _SinisterNatureRepository.ListAsync(spec, cancellationToken);
        return _mapper.Map<List<SinisterNatureDto>>(allSinisterNatures);
    }
}