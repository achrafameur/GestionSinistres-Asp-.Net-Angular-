using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.Update;

public class UpdateFeatureCommand : IRequest
{
    public UpdateFeatureCommand(int featureId, string title, string? description, string? symbol, int? @fixed,
        float? minimum, float? maximum, bool alterable, bool isPrincipal, int? rankShow, int? chainId, int natureId)
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
        NatureId = natureId;
    }

    public int FeatureId { get; set; }
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
    public int NatureId { get; set; }
}