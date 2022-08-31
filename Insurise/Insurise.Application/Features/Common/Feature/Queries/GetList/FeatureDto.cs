namespace Insurise.Application.Features.Common.Feature.Queries.GetList;

public class FeatureDto
{
    public FeatureDto(int featureId, string title, string? description, string? symbol, int? @fixed, float? minimum,
        float? maximum, bool alterable, bool isPrincipal, int? rankShow, int? chainId, string? chain, int natureId,
        string nature)
    {
        FeatureId = featureId;
        Title = title;
        Description = description;
        Symbol = symbol;
        Fixed = @fixed;
        Minimum = minimum;
        Maximum = maximum;
        Alterable = alterable;
        IsPrincipal = isPrincipal;
        RankShow = rankShow;
        ChainId = chainId;
        Chain = chain;
        NatureId = natureId;
        Nature = nature;
        IsChecked = false;
    }

    public int FeatureId { get; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public string? Symbol { get; set; }
    public int? Fixed { get; set; }
    public float? Minimum { get; set; }
    public float? Maximum { get; set; }
    public bool Alterable { get; set; }
    public bool IsPrincipal { get; set; }

    public int? RankShow { get; set; }
    public int? ChainId { get; set; }
    public string? Chain { get; set; }
    public int NatureId { get; set; }
    public string Nature { get; set; }
    public bool IsChecked { get; set; }
    public DateTime CreationDate { get; }
}