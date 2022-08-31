using Insurise.Application.Exceptions;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductWarranty;

public class DeleteProductWarrantyEventHandler : IRequestHandler<DeleteProductWarantyCommand>
{
    private readonly IRepository<Core.Entities.Production.ProductAggregate.Product> _repository;

    public DeleteProductWarrantyEventHandler(IRepository<Core.Entities.Production.ProductAggregate.Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteProductWarantyCommand command, CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = command.ProductId,
            LoadChildren = true,
            Children = new List<string> {"Branch", "ProductWarrantiesNotDeleted", "ProductWarranties.Warranty"},
            IsPagingEnabled = false
        };
        var warrantiesByProductIdSpec = new ProductSpecSingleResult(filter);


        var productToUpdate = await _repository.GetBySpecAsync(warrantiesByProductIdSpec);


        if (productToUpdate == null) throw new ProductNotFoundException(command.ProductId);
        var productWarrantyToDelete = productToUpdate.ProductWarranties.FirstOrDefault(x => x.Id == command.Id);
        if (productWarrantyToDelete == null) throw new ProductWarrantyNotFoundException(command.Id);
        productWarrantyToDelete.IsDeleted = true;
        productWarrantyToDelete.Rank = 0;
        productToUpdate.ReorderProductWarranties();
        await _repository.UpdateAsync(productToUpdate, cancellationToken);
        return Unit.Value;
    }
}