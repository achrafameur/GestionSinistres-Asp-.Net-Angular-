using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;
using Ardalis.Result;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductsList;

public class GetProductListQuery : IRequest<Result<List<ProductDto>>>
{
    public GetProductListQuery()
    {
    }

    public GetProductListQuery(ProductFilterDto? filterDto)
    {
        this.filterDto = filterDto;
    }

    public ProductFilterDto? filterDto { get; set; }
}