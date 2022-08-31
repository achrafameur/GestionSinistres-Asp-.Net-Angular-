using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.Add;

public class AddFeatureCommand : IRequest<int>
{
    public AddFeatureCommand(string title, string? description, string? symbol, int? @fixed, float? minimum,
        float? maximum, bool alterable, bool isPrincipal, int? rankShow, int? chainId, int natureId)
    {
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

    public override string ToString()
    {
        return
            $"Characteristic : Title = {Title} ; Description = {Description};Symbole ={Symbol};Fixed = {Fixed};Minimum = {Minimum};Maximum = {Maximum};Alterable ={Alterable};IsPrincipal= {IsPrincipal}";
    }
}