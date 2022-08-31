using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductFeesDetail;

public class GetProductFeesDetailQuery : IRequest<List<ProductFeeDto>>
{
    public GetProductFeesDetailQuery(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}
