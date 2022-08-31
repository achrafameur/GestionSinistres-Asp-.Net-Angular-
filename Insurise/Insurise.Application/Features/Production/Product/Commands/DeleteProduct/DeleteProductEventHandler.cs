using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProduct;

public class DeleteProductEventHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IRepository<ProductEntity.Product> _productRepository;

    public DeleteProductEventHandler(IRepository<ProductEntity.Product> productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var productToDelete = await _productRepository.GetByIdAsync(command.ProductId, cancellationToken);
        if (productToDelete == null) throw new ProductNotFoundException(command.ProductId);
        productToDelete.IsDeleted = true;
        await _productRepository.UpdateAsync(productToDelete, cancellationToken);

        return Unit.Value;
    }
}