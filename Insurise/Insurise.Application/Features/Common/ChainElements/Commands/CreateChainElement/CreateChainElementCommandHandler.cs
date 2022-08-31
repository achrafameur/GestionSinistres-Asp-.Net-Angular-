using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Commands.CreateChainElement;

public class CreateChainElementCommandHandler : IRequestHandler<CreateChainElementCommand, int>
{
    private readonly IRepository<ChainElement> _chainElementRepository;
    private readonly IMapper _mapper;

    public CreateChainElementCommandHandler(IRepository<ChainElement> chainElementRepository, IMapper mapper)
    {
        _chainElementRepository = chainElementRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateChainElementCommand request, CancellationToken cancellationToken)
    {
        var chainElement = _mapper.Map<ChainElement>(request);
        chainElement = await _chainElementRepository.AddAsync(chainElement, cancellationToken);
        return chainElement.Id;
    }
}