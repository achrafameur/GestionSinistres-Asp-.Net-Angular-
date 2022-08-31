using MediatR;

namespace Insurise.Application.Features.Production.Fees.Commands.AddFees;

public class CreateFeesCommand : IRequest<int>
{
    public CreateFeesCommand(string title, string symbol, string description, string equation, string type)
    {
        Title = title;
        Symbol = symbol;
        Description = description;
        Equation = equation;
        Type = type;
    }

    public string Title { get; set; }
    public string Symbol { get; set; }
    public string Description { get; set; }
    public string Equation { get; set; }
    public string Type { get; set; }

    public override string ToString()
    {
        return
            $"Fees : Title = {Title} ; Description = {Description}; Symbol={Symbol} ; Equation={Equation} ; Type={Type} ;";
    }
}