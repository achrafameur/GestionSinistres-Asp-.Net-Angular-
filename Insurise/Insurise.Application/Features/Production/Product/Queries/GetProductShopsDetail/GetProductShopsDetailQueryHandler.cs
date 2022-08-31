using AutoMapper;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Production.Products;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductShopsDetail;

public class GetProductShopsDetailQueryHandler : IRequestHandler<GetProductShopsDetailQuery, List<ProductShopDto>>
{
    private readonly IRepository<ProductShop> _repository;
    private readonly IMapper _mapper;

    public GetProductShopsDetailQueryHandler(IMapper mapper, IRepository<ProductShop> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ProductShopDto>> Handle(GetProductShopsDetailQuery request, CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> {"Shop"},
            IsPagingEnabled = false
        };
        var productShopsByProductIdSpec = new ProductShopSpec(filter);
        var productShopsByProduct = await _repository.ListAsync(productShopsByProductIdSpec, cancellationToken);
        var mappedProduct = _mapper.Map<List<ProductShopDto>>(productShopsByProduct);
        return mappedProduct;
    }
}