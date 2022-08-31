using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.UpdateProductWarranty;

public class UpdateProductWarrantyCommand : IRequest
{
    public UpdateProductWarrantyCommand(int id, bool mandatory, int rank)
    {
        Id = id;
        Mandatory = mandatory;
        Rank = rank;
    }

    public int Id { get; set; }
    public bool Mandatory { get; set; }
    public int Rank { get; set; }
}