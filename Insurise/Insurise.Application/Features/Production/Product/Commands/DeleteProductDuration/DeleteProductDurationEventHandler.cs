using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.DeleteProductDuration;

public class DeleteProductDurationEventHandler : IRequestHandler<DeleteProductDurationCommand>
{
    private readonly IRepository<ProductDuration> _productDurationRepository;

    public DeleteProductDurationEventHandler(IRepository<ProductDuration> productDurationRepository)
    {
        _productDurationRepository = productDurationRepository;
    }

    public async Task<Unit> Handle(DeleteProductDurationCommand command, CancellationToken cancellationToken)
    {
        var filter = new ProductDurationFilter
        {
            Id = command.Id,
            LoadChildren = true,
            Children = new List<string> { "Proportions" },
            IsPagingEnabled = false
        };
        var productDurationsByProductIdSpec = new ProductDurationSpecSingleResult(filter);
        var productDurationToDelete = await _productDurationRepository.GetBySpecAsync(productDurationsByProductIdSpec, cancellationToken); 
        if (productDurationToDelete == null) throw new ProductDurationNotFoundException(command.Id);
        productDurationToDelete.IsDeleted = true;
        foreach (var proportion in productDurationToDelete.Proportions)
        {
            proportion.IsDeleted = true;
        }
       
        await _productDurationRepository.UpdateAsync(productDurationToDelete, cancellationToken);

        return Unit.Value;
    }
}
