using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetDurationsDetail;

public class GetDurationsDetailQuery : IRequest<List<ProductDurationsDto>>
{
    public GetDurationsDetailQuery(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}