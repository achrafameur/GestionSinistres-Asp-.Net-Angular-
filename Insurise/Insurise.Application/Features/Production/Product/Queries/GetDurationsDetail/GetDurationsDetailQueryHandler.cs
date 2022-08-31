using AutoMapper;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Queries.GetDurationsDetail;

public class GetDurationsDetailQueryHandler : IRequestHandler<GetDurationsDetailQuery, List<ProductDurationsDto>>
{
    private readonly IRepository<ProductEntity.Product> _ProductRepository;
    private readonly IMapper _mapper;

    public GetDurationsDetailQueryHandler(IMapper mapper, IRepository<ProductEntity.Product> ProductRepository)
    {
        _mapper = mapper;
        _ProductRepository = ProductRepository;
    }

    public async Task<List<ProductDurationsDto>> Handle(GetDurationsDetailQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string>
            {
                "Branch", "ProductDurations", "ProductDurations.Duration", "ProductDurationsProportionsNotDeleted",
                "ProductDurations.Proportions.Proportion"
            },
            IsPagingEnabled = false
        };
        var warrantiesByProductIdSpec = new ProductSpecSingleResult(filter);


        var durationsByProduct = await _ProductRepository.GetBySpecAsync(warrantiesByProductIdSpec);
        var mappedProduct =
            _mapper.Map<List<ProductDurationsDto>>(durationsByProduct?.ProductDurations.OrderBy(x => x.actif));
        return mappedProduct;
    }
}
