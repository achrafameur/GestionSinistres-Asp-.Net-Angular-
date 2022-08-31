namespace Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;

public class ChainElementDto
{
    public ChainElementDto(string title, int? chainId, int chainElementId)
    {
        Title = title;
        ChainId = chainId;
        ChainElementId = chainElementId;
    }

    public int ChainElementId { get; set; }
    public string Title { get; set; }
    public int? ChainId { get; set; }
}