using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Commands.DeleteChainElement;

public class DeleteChainElementCommand : IRequest
{
    public DeleteChainElementCommand(int id)
    {
        ChainElementId = id;
    }

    public int ChainElementId { get; set; }
}