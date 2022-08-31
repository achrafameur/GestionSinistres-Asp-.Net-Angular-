using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductWarranty;

public class DeleteProductWarantyCommand : IRequest
{
    public DeleteProductWarantyCommand(int id, int productId)
    {
        Id = id;
        ProductId = productId;
    }

    public int Id { get; set; }
    public int ProductId { get;   set; }
}
