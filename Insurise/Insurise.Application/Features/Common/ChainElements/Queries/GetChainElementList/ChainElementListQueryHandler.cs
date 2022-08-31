using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;

public class ChainElementListQueryHandler : IRequestHandler<ChainElementListQuery, List<ChainElementDto>>
{
    private readonly IRepository<ChainElement> _chainElementRepository;
    private readonly IMapper _mapper;

    public ChainElementListQueryHandler(IRepository<ChainElement> chainElementRepository, IMapper mapper)
    {
        _chainElementRepository = chainElementRepository;
        _mapper = mapper;
    }

    public async Task<List<ChainElementDto>> Handle(ChainElementListQuery request,
        CancellationToken cancellationToken)
    {
        var all = (await _chainElementRepository.ListAsync(cancellationToken)).OrderBy(x => x.Title);
        return _mapper.Map<List<ChainElementDto>>(all);
    }
}