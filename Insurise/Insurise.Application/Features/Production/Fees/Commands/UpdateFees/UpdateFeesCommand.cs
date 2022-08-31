using MediatR;

namespace Insurise.Application.Features.Production.Fees.Commands.UpdateFees;

public class UpdateFeesCommand : IRequest
{
    public UpdateFeesCommand(int feesId, string title, string symbol, string description, string equation, int type)
    {
        FeesId = feesId;
        Title = title;
        Symbol = symbol;
        Description = description;
        Equation = equation;
        Type = type;
    }

    public int FeesId { get; set; }
    public string Title { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; }
    public string Equation { get; set; }
    public int Type { get; set; }
}