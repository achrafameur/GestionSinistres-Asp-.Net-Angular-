using AutoMapper;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductDetail;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDto>
{
    private readonly IRepository<ProductEntity.Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductDetailQueryHandler(IMapper mapper, IRepository<ProductEntity.Product> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<ProductDto> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var customerByProductIdSpec = new ProductByIdSpec(request.ProductId);

        var product = await _productRepository.GetBySpecAsync(customerByProductIdSpec, cancellationToken);
        var mappedProduct = _mapper.Map<ProductDto>(product);
        return mappedProduct;
    }
}