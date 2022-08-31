using Ardalis.Result;
using Ardalis.Specification;
using AutoMapper;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductsList;

public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, Result<List<ProductDto>>>
{
    private readonly IRepository<ProductEntity.Product> _repository;
    private readonly IMapper _mapper;

    public GetProductListQueryHandler(IMapper mapper, IRepository<ProductEntity.Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Result<List<ProductDto>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var filter = _mapper.Map<ProductFilter>(request.filterDto);
        filter.Children = new List<string> {"Branch"};
        var spec = new ProductSpec(filter);
        var allProductes = await _repository.ListAsync(spec, cancellationToken);
        if (allProductes == null) return Result<List<ProductDto>>.NotFound();
        filter.IsPagingEnabled = false;
        var filterSpecification = new ProductSpec(filter);
        var totalItems = await _repository.CountAsync(filterSpecification);
        var mappedProduct = _mapper.Map<List<ProductDto>>(allProductes);
        var totalPages = request.filterDto.PageSize > 0
            ? int.Parse(Math.Ceiling((decimal) totalItems / request.filterDto.PageSize).ToString())
            : totalItems > 0
                ? 1
                : 0;
        var _pagedInfo = new PagedInfo(request.filterDto.Page, request.filterDto.PageSize, totalPages, totalItems);
        return new Result<List<ProductDto>>(mappedProduct).ToPagedResult(_pagedInfo);
    }
}