using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductShop;

public class DeleteProductShopCommand : IRequest
{
    public DeleteProductShopCommand(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}