using AutoMapper;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Queries.GetWarrantiesDetail;

public class GetWarrantiesDetailQueryHandler : IRequestHandler<GetWarrantiesDetailQuery, List<ProductWarrantyDto>>
{
    private readonly IRepository<ProductEntity.Product> _ProductRepository;
    private readonly IMapper _mapper;

    public GetWarrantiesDetailQueryHandler(IMapper mapper, IRepository<ProductEntity.Product> ProductRepository)
    {
        _mapper = mapper;
        _ProductRepository = ProductRepository;
    }

    public async Task<List<ProductWarrantyDto>> Handle(GetWarrantiesDetailQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> {"Branch", "ProductWarrantiesNotDeleted", "ProductWarranties.Warranty"},
            IsPagingEnabled = false
        };
        var warrantiesByProductIdSpec = new ProductSpecSingleResult(filter);


        var warrantiesByProduct = await _ProductRepository.GetBySpecAsync(warrantiesByProductIdSpec);
        var mappedProduct =
            _mapper.Map<List<ProductWarrantyDto>>(warrantiesByProduct?.ProductWarranties.OrderBy(x => x.Rank));
        return mappedProduct;
    }
}