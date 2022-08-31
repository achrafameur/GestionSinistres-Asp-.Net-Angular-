using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.ChainElements.Commands.UpdateChainElement;

public class UpdateChainElementCommandHandler : IRequestHandler<UpdateChainElementCommand>
{
    private readonly IRepository<ChainElement> _chainElementRepository;
    private readonly IMapper _mapper;

    public UpdateChainElementCommandHandler(IRepository<ChainElement> chainElementRepository, IMapper mapper)
    {
        _chainElementRepository = chainElementRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateChainElementCommand request, CancellationToken cancellationToken)
    {
        var chainElementToUpdate =
            await _chainElementRepository.GetByIdAsync(request.ChainElementId, cancellationToken);
        if (chainElementToUpdate == null) throw new ChainNotFoundException(request.ChainElementId);
        _mapper.Map(request, chainElementToUpdate, typeof(UpdateChainElementCommand), typeof(ChainElement));
        await _chainElementRepository.UpdateAsync(chainElementToUpdate, cancellationToken);
        return Unit.Value;
    }
}