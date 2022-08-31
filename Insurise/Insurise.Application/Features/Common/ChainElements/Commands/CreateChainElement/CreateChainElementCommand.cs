using MediatR;

namespace Insurise.Application.Features.Common.ChainElements.Commands.CreateChainElement;

public class CreateChainElementCommand : IRequest<int>
{
    private readonly DateTime _creationDate = DateTime.UtcNow;
    public CreateChainElementCommand()
    {
        
    }
    public CreateChainElementCommand(string title, int chainId)
    {
        Title = title;
        ChainId = chainId;
    }

    public string Title { get; set; }
    public int ChainId { get; set; }

    public override string ToString()
    {
        return $"ChainElement name: {Title}; Created on:{DateTime.Now}";
    }
}