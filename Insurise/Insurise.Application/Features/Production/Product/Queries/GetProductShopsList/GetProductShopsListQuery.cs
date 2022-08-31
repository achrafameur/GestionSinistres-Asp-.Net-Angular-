using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductShopsList;

public class GetProductShopsListQuery : IRequest<List<ProductShopDto>>
{
    public GetProductShopsListQuery(int? productId)
    {
        ProductId = productId;
    }

    public int? ProductId { get; }
}