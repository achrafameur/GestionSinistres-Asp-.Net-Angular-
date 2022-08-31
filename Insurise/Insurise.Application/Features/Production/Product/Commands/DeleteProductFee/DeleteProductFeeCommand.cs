using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductFee;

public class DeleteProductFeeCommand : IRequest
{
    public DeleteProductFeeCommand(int id, int productId)
    {
        Id = id;
        ProductId = productId;
    }

    public int Id { get; set; }
    public int ProductId { get;   set; }
}
