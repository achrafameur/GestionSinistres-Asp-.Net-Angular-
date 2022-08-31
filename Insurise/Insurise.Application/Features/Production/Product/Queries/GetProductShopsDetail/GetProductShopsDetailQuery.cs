using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductShopsDetail;

public class GetProductShopsDetailQuery : IRequest<List<ProductShopDto>>
{
    public GetProductShopsDetailQuery(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}
