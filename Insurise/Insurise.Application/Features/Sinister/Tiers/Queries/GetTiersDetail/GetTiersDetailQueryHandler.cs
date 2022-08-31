using AutoMapper;
using Insurise.Core.Specifications.Filters.Sinister.ThirdParties;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;

public class GetTiersDetailQueryHandler : IRequestHandler<GetTiersDetailQuery, TiersDto>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> _TiersRepository;
    private readonly IMapper _mapper;

    public GetTiersDetailQueryHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Tiers> TiersRepository)
    {
        _mapper = mapper;
        _TiersRepository = TiersRepository;
    }

    public async Task<TiersDto> Handle(GetTiersDetailQuery request, CancellationToken cancellationToken)
    {
        var filter = new ThirdPartyFilter
        {
            TiersId = request.TiersId,
            LoadChildren = true,
            Children = new List<string> {"TiersCompany"},
            IsPagingEnabled = false
        };
        var companyIdSpec = new ThirdPartySpecSingleResult(filter);
        var tiers = await _TiersRepository.GetBySpecAsync(companyIdSpec);
        var returnedTiers = _mapper.Map<TiersDto>(tiers);

        return returnedTiers;
    }
}