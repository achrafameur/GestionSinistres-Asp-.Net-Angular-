using AutoMapper;
using Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;
using Insurise.Core.Specifications.Filters.Sinister.ThirdParties;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersList;

public class GetTiersListQueryHandler : IRequestHandler<GetTiersListQuery, List<TiersDto>>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> _TiersRepository;
    private readonly IMapper _mapper;

    public GetTiersListQueryHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> TiersRepository)
    {
        _mapper = mapper;
        _TiersRepository = TiersRepository;
    }

    public async Task<List<TiersDto>> Handle(GetTiersListQuery request, CancellationToken cancellationToken)
    {
        var filter = new ThirdPartyFilter
        {
            LoadChildren = true,
            Children = new List<string> {"TiersCompany"},
            IsPagingEnabled = false
        };
        var spec = new ThirdPartySpec(filter);
        var allTiers = await _TiersRepository.ListAsync(spec, cancellationToken);
        return _mapper.Map<List<TiersDto>>(allTiers);
    }
}