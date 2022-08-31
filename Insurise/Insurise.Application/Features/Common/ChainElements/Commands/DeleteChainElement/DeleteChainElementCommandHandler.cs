using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.ChainElements.Commands.DeleteChainElement;

public class DeleteChainElementCommandHandler : IRequestHandler<DeleteChainElementCommand>
{
    private readonly IRepository<ChainElement> _chainElementRepository;
    private readonly IMapper _mapper;

    public DeleteChainElementCommandHandler(IRepository<ChainElement> chainElementRepository, IMapper mapper)
    {
        _chainElementRepository = chainElementRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteChainElementCommand request, CancellationToken cancellationToken)
    {
        var chainElementToDelete =
            await _chainElementRepository.GetByIdAsync(request.ChainElementId, cancellationToken);
        if (chainElementToDelete == null) throw new ChainNotFoundException(request.ChainElementId);
        await _chainElementRepository.DeleteAsync(chainElementToDelete, cancellationToken);
        return Unit.Value;
    }
}