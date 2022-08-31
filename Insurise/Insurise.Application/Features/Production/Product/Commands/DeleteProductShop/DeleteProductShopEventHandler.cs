using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductShop;

public class DeleteProductShopEventHandler : IRequestHandler<DeleteProductShopCommand>
{
    private readonly IRepository<ProductShop> _productShopRepository;

    public DeleteProductShopEventHandler(IRepository<ProductShop> productShopRepository)
    {
        _productShopRepository = productShopRepository;
    }

    public async Task<Unit> Handle(DeleteProductShopCommand command, CancellationToken cancellationToken)
    {
        var productShopToDelete = await _productShopRepository.GetByIdAsync(command.Id, cancellationToken);
        if (productShopToDelete == null) throw new ProductShopNotFoundException(command.Id);
        productShopToDelete.IsDeleted = true;
        await _productShopRepository.UpdateAsync(productShopToDelete, cancellationToken);

        return Unit.Value;
    }
}