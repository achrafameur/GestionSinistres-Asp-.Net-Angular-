using MediatR;

namespace Insurise.Application.Features.Common.Shops.Commands.DeleteShops;

public class DeleteShopsCommand : IRequest
{
    public DeleteShopsCommand(int id)
    {
        ShopId = id;
    }

    public int ShopId { get; }
}