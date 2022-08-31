using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;

namespace Insurise.Application.Features.Common.Chains.Queries.GetChainList;

public class ChainDto
{
    public ChainDto(int chainId, string title, ICollection<ChainElementDto> chainElements)
    {
        ChainId = chainId;
        Title = title;
        Elements = chainElements;
    }

    public int ChainId { get; set; }
    public string Title { get; set; }
    public ICollection<ChainElementDto> Elements { get; set; }
}