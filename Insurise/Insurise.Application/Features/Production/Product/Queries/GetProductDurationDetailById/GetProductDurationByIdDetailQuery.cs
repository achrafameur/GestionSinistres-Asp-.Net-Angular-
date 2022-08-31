using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductDurationDetailById;

public class GetProductDurationByIdDetailQuery : IRequest<ProductDurationsDto>
{
    public GetProductDurationByIdDetailQuery(int? id)
    {
        Id = id;
    }

    public int? Id { get; }
}
