using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductDetail;

public class GetProductDetailQuery : IRequest<ProductDto>
{
    public GetProductDetailQuery(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}