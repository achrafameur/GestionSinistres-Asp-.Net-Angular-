using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Commands.UpdateProduct;

public class UpdateProductEventHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IRepository<ProductEntity.Product> _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductEventHandler(IMapper mapper, IRepository<ProductEntity.Product> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productToUpdate = await _productRepository.GetByIdAsync(request.ProductId, cancellationToken);

        if (productToUpdate == null) throw new ProductNotFoundException(request.ProductId);

        _mapper.Map(request, productToUpdate, typeof(UpdateProductCommand), typeof(ProductEntity.Product));

        await _productRepository.UpdateAsync(productToUpdate, cancellationToken);

        return Unit.Value;
    }
}