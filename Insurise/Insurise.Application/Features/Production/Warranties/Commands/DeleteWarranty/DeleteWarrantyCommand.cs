using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarranty;

public class DeleteWarrantyCommand : IRequest
{
    public DeleteWarrantyCommand(int warrantyId)
    {
        WarrantyId = warrantyId;
    }

    public int WarrantyId { get; set; }
}