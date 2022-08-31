using AutoMapper;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Production.Products;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductFeesDetail;

public class GetProductFeesDetailQueryHandler : IRequestHandler<GetProductFeesDetailQuery, List<ProductFeeDto>>
{
    private readonly IRepository<ProductEntity.Product> _repository;
    private readonly IMapper _mapper;

    public GetProductFeesDetailQueryHandler(IMapper mapper, IRepository<ProductEntity.Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<ProductFeeDto>> Handle(GetProductFeesDetailQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> {"Branch", "ProductFeesNotDeleted", "ProductFees.Fee"},
            IsPagingEnabled = false
        };
        var feesByProductIdSpec = new ProductSpecSingleResult(filter);
        var feesByProduct = await _repository.GetBySpecAsync(feesByProductIdSpec, cancellationToken);
        var mappedProduct = _mapper.Map<List<ProductFeeDto>>(feesByProduct?.ProductFees.OrderBy(x => x.Rank));
        return mappedProduct;
    }
}
