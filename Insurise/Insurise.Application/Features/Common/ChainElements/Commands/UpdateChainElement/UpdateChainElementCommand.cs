using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Commands.UpdateChainElement;

public class UpdateChainElementCommand : IRequest
{
    public UpdateChainElementCommand()
    {

    }
    public UpdateChainElementCommand(int id, string title, int chainId)
    {
        ChainElementId = id;
        Title = title;
        ChainId = chainId;
    }

    public int ChainElementId { get; set; }
    public string Title { get; set; }
    public int ChainId { get; set; }
}