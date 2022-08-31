using AutoMapper;
using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementDetail;

public class GetChainElementDetailQueryHandler : IRequestHandler<GetChainElementDetailQuery, ChainElementDto>
{
    private readonly IRepository<ChainElement> _chainElementRepository;
    private readonly IMapper _mapper;

    public GetChainElementDetailQueryHandler(IRepository<ChainElement> chainElementRepository, IMapper mapper)
    {
        _chainElementRepository = chainElementRepository;
        _mapper = mapper;
    }

    public async Task<ChainElementDto> Handle(GetChainElementDetailQuery request,
        CancellationToken cancellationToken)
    {
        var chainElement = await _chainElementRepository.GetByIdAsync(request.Id, cancellationToken);
        var chainElementDetailDto = _mapper.Map<ChainElementDto>(chainElement);
        return chainElementDetailDto;
    }
}