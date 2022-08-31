using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using MediatR;

namespace Insurise.Application.Features.Common.Chains.Commands.CreateChain;

public class CreateChainCommand : IRequest<int>
{
    public CreateChainCommand(string title, List<ChainElementDto>? elements)
    {
        Title = title;
        Elements = elements;
    }

    public string Title { get; }

    public List<ChainElementDto>? Elements { get; }
}