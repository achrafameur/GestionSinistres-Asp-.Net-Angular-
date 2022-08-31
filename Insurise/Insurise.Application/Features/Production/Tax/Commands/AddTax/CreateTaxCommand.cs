using MediatR;

namespace Insurise.Application.Features.Production.Tax.Commands.AddTax;

public class CreateTaxCommand : IRequest<int>
{
    public CreateTaxCommand(string title, string description, double coefficient, double constant)
    {
        Title = title;
        Description = description;
        Coefficient = coefficient;
        Constant = constant;
    }

    public string Title { get; set; }
    public string Description { get; set; }
    public double Coefficient { get; set; }
    public double Constant { get; set; }

    public override string ToString()
    {
        return
            $"Tax : Title = {Title} ; Coefficient = {Coefficient} ; Constant = {Constant} ; Description = {Description} ";
    }
}