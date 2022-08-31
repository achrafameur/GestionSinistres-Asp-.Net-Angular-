using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using MediatR;

namespace Insurise.Application.Features.Common.Chains.Commands.UpdateChain;

public class UpdateChainCommand : IRequest
{
    public UpdateChainCommand()
    {

    }
    public UpdateChainCommand(string title, List<ChainElementDto>? chainElements, int chainId)
    {
        Title = title;
        Elements = chainElements;
        ChainId = chainId;
    }

    public int ChainId { get; set; }
    public string Title { get; set; }

    public List<ChainElementDto>? Elements { get; set; }

    public override string ToString()
    {
        return $"Chain name: {Title};  Created on:{DateTime.Now}";
    }
}