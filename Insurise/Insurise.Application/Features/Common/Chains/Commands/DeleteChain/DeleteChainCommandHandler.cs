using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Chains.Commands.DeleteChain;

public class DeleteChainCommandHandler : IRequestHandler<DeleteChainCommand>
{
    private readonly IRepository<Chain> _chainRepository;


    public DeleteChainCommandHandler(IRepository<Chain> chainRepository)
    {
        _chainRepository = chainRepository;
    }

    public async Task<Unit> Handle(DeleteChainCommand command, CancellationToken cancellationToken)
    {
        var chainToDelete = await _chainRepository.GetByIdAsync(command.ChainId, cancellationToken);

        if (chainToDelete == null) throw new ChainNotFoundException(command.ChainId);

        await _chainRepository.DeleteAsync(chainToDelete, cancellationToken);
        return Unit.Value;
    }
}