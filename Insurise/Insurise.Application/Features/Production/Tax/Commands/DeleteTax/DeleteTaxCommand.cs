using MediatR;

namespace Insurise.Application.Features.Production.Tax.Commands.DeleteTax;

public class DeleteTaxCommand : IRequest
{
    public DeleteTaxCommand(int taxId)
    {
        TaxId = taxId;
    }

    public int TaxId { get; set; }
}