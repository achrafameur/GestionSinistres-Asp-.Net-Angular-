using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Commun.Chains;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Chains.Commands.UpdateChain;

public class UpdateChainCommandHandler : IRequestHandler<UpdateChainCommand>
{
    private readonly IRepository<Chain> _chainRepository;
    private readonly IMapper _mapper;

    public UpdateChainCommandHandler(IMapper mapper, IRepository<Chain> chainRepository)
    {
        _mapper = mapper;
        _chainRepository = chainRepository;
    }

    public async Task<Unit> Handle(UpdateChainCommand request, CancellationToken cancellationToken)
    {
        var elements = new List<ChainElement>();
        var filter = new ChainFilter
        {
            ChainId = request.ChainId,
            LoadChildren = true,
            Children = new List<string> {"Elements"},
            IsPagingEnabled = false
        };
        var chainIdSpec = new ChainSpecSingleResult(filter);


        var chainToUpdate = await _chainRepository.GetBySpecAsync(chainIdSpec, cancellationToken);
        if (chainToUpdate == null) throw new ChainNotFoundException(request.ChainId);
        _mapper.Map(request, chainToUpdate, typeof(UpdateChainCommand), typeof(Chain));

        if (request.Elements != null)
        {
            foreach (var element in request.Elements)
            {
                var elementToUpdate = chainToUpdate.Elements
                    .FirstOrDefault(x => x.Id == element.ChainElementId);
                if (elementToUpdate == null)
                {
                    var chainElementToAdd = _mapper.Map<ChainElement>(element);
                    elements.Add(chainElementToAdd);
                }
                else
                {
                    _mapper.Map(element, elementToUpdate, typeof(ChainElementDto), typeof(ChainElement));
                }
            }

            chainToUpdate.AddChainElement(elements);
        }

        await _chainRepository.UpdateAsync(chainToUpdate, cancellationToken);

        return Unit.Value;
    }
}