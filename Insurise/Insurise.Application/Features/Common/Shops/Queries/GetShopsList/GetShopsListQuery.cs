using InsuriseDTO.Common;
using MediatR;

namespace Insurise.Application.Features.Common.Shops.Queries.GetShopsList;

public class GetShopsListQuery : IRequest<List<ShopDto>>
{
    public GetShopsListQuery()
    {
    }

    public GetShopsListQuery(int? productId)
    {
        ProductId = productId;
    }

    public int? ProductId { get; }
}