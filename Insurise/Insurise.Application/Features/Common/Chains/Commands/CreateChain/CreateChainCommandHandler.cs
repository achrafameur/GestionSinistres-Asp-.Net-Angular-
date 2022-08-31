using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Chains.Commands.CreateChain;

public class CreateChainCommandHandler : IRequestHandler<CreateChainCommand, int>
{
    private readonly IRepository<Chain> _chainRepository;
    private readonly IMapper _mapper;

    public CreateChainCommandHandler(IMapper mapper, IRepository<Chain> chainRepository)
    {
        _mapper = mapper;
        _chainRepository = chainRepository;
    }

    public async Task<int> Handle(CreateChainCommand request, CancellationToken cancellationToken)
    {
        var chain = _mapper.Map<Chain>(request);
        var elements = new List<ChainElement>();
        if (request.Elements != null)
        {
            foreach (var element in request.Elements)
            {
                if (chain == null) throw new ChainNotFoundException(element);
                var chainElementToAdd = _mapper.Map<ChainElement>(element);
                elements.Add(chainElementToAdd);
            }

            chain.AddChainElement(elements);
        }

        chain = await _chainRepository.AddAsync(chain, cancellationToken);
        return chain.Id;
    }
}