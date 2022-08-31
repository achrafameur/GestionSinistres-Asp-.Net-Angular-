using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductDurationsDetail;

public class GetProductDurationsDetailQuery : IRequest<List<ProductDurationsDto>>
{
    public GetProductDurationsDetailQuery(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}
