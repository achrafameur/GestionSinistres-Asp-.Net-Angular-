using MediatR;

namespace Insurise.Application.Features.Production.Tax.Commands.UpdateTax;

public class UpdateTaxCommand : IRequest
{
    public UpdateTaxCommand(int taxId, string title, string description, double coefficient, double constant)
    {
        TaxId = taxId;
        Title = title;
        Description = description;
        Coefficient = coefficient;
        Constant = constant;
    }

    public int TaxId { get; }
    public string Title { get; }
    public string Description { get; }
    public double Coefficient { get; }
    public double Constant { get; }
}