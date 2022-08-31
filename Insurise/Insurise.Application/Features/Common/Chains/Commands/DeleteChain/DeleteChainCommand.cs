using MediatR;

namespace Insurise.Application.Features.Common.Chains.Commands.DeleteChain;

public class DeleteChainCommand : IRequest
{
    public DeleteChainCommand(int chainId)
    {
        ChainId = chainId;
    }

    public int ChainId { get; }
}