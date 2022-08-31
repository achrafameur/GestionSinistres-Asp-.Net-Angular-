using AutoMapper;
using Insurise.Application.Features.Common.Chains.Queries.GetChainList;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Commun.Chains;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Chains.Queries.GetChainDetail;

public class GetChainDetailQueryHandler : IRequestHandler<GetChainDetailQuery, ChainDto>
{
    private readonly IRepository<Chain> _chainRepository;
    private readonly IMapper _mapper;

    public GetChainDetailQueryHandler(IMapper mapper, IRepository<Chain> chainRepository)
    {
        _chainRepository = chainRepository;
        _mapper = mapper;
    }

    public async Task<ChainDto> Handle(GetChainDetailQuery request, CancellationToken cancellationToken)
    {
        var filter = new ChainFilter
        {
            ChainId = request.Id,
            LoadChildren = true,
            Children = new List<string> {"Elements"},
            IsPagingEnabled = false
        };
        var chainIdSpec = new ChainSpecSingleResult(filter);


        var chain = await _chainRepository.GetBySpecAsync(chainIdSpec, cancellationToken);
        var chainDetailDto = _mapper.Map<ChainDto>(chain);
        return chainDetailDto;
    }
}