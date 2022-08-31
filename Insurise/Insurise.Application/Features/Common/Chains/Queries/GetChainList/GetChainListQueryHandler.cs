using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Commun.Chains;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Chains.Queries.GetChainList;

public class GetChainListQueryHandler : IRequestHandler<GetChainListQuery, List<ChainDto>>
{
    private readonly IRepository<Chain> _chainRepository;
    private readonly IMapper _mapper;


    public GetChainListQueryHandler(IMapper mapper, IRepository<Chain> chainRepository)
    {
        _mapper = mapper;
        _chainRepository = chainRepository;
    }

    public async Task<List<ChainDto>> Handle(GetChainListQuery request, CancellationToken cancellationToken)
    {
        var filter = new ChainFilter
        {
            LoadChildren = true,
            Children = new List<string> {"Elements"},
            IsPagingEnabled = false
        };
        var spec = new ChainSpec(filter);

        var chains = await _chainRepository.ListAsync(spec, cancellationToken);
        var mappedChains = _mapper.Map<List<ChainDto>>(chains);
        return mappedChains;
    }
}