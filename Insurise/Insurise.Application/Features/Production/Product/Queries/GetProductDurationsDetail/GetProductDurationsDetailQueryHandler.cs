using AutoMapper;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces; 
using InsuriseDTO.Production.Products;
using MediatR; 

namespace Insurise.Application.Features.Production.Product.Queries.GetProductDurationsDetail;

public class GetProductDurationsDetailQueryHandler : IRequestHandler<GetProductDurationsDetailQuery, List<ProductDurationsDto>>
{
    private readonly IRepository<ProductDuration> _productDurationRepository;
    private readonly IMapper _mapper;

    public GetProductDurationsDetailQueryHandler(IMapper mapper, IRepository<ProductDuration>productDurationRepository)
    {
        _mapper = mapper;
        _productDurationRepository = productDurationRepository;
    }

    public async Task<List<ProductDurationsDto>> Handle(GetProductDurationsDetailQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new ProductDurationFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> { "Proportions", "Proportions.Proportion", "Product", "Duration" },
            IsPagingEnabled = false
        };
        var ProductDurationsByProductIdSpec = new ProductDurationSpec(filter);
        var ProductDurationsByProduct = await _productDurationRepository.ListAsync(ProductDurationsByProductIdSpec);
        var mappedProduct = _mapper.Map<List<ProductDurationsDto>>(ProductDurationsByProduct);
        return mappedProduct;
    }
}
