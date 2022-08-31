using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetWarrantiesDetail;

public class GetWarrantiesDetailQuery : IRequest<List<ProductWarrantyDto>>
{
    public GetWarrantiesDetailQuery(int productId)
    {
        ProductId = productId;
    }

    public int ProductId { get; }
}