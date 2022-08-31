using Insurise.Application.Exceptions;
using Insurise.Application.Features.Production.Product.Commands.DeleteProduct;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using PackageEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductFee;

public class DeleteProductFeeEventHandler : IRequestHandler<DeleteProductFeeCommand>
{
    private readonly IRepository<PackageEntity.Product> _repository;

    public DeleteProductFeeEventHandler(IRepository<PackageEntity.Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProductFeeCommand command, CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = command.ProductId,
            LoadChildren = true,
            Children = new List<string> { "ProductFees" },
            IsPagingEnabled = false
        };
        var productSpec = new ProductSpecSingleResult(filter);
        var productToUpdate = await _repository.GetBySpecAsync(productSpec, cancellationToken);
        if (productToUpdate == null) throw new ProductNotFoundException(command.ProductId);
        var productFeeToDelete = productToUpdate.ProductFees.FirstOrDefault(x => x.Id == command.Id);
        if (productFeeToDelete == null) throw new ProductFeeNotFoundException(command.Id);
        productFeeToDelete.IsDeleted = true;
        productFeeToDelete.Rank = 0; 
        productToUpdate.ReorderProductFees();
        await _repository.UpdateAsync(productToUpdate, cancellationToken);
        return Unit.Value;
    }
}
