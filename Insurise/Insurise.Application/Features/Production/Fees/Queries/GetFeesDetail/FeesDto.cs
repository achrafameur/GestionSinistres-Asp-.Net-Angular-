using Insurise.Core.Entities.Common;

namespace Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;

public class FeesDto
{
    public FeesDto(int feesId, string title, string symbol, string description, FeesType type, string equation)
    {
        FeesId = feesId;
        Title = title;
        Symbol = symbol;
        Description = description;
        Type = type;
        Equation = equation;
    }

    public int FeesId { get; set; }
    public string Title { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; }
    public string Equation { get; set; }
    public FeesType Type { get; set; }
}