using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProduct;

public class DeleteProductCommand : IRequest
{
    public DeleteProductCommand(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; set; }
}