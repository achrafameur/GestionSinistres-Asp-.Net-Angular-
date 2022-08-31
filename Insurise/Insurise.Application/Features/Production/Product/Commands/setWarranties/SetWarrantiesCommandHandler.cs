using Insurise.Application.Exceptions;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using PackageEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Commands.setWarranties;

public class SetWarrantiesCommandHandler : IRequestHandler<SetWarrantiesCommand>
{
    private readonly IRepository<PackageEntity.Product> _repository;

    public SetWarrantiesCommandHandler(IRepository<PackageEntity.Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(SetWarrantiesCommand request, CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> {"ProductWarranties"},
            IsPagingEnabled = false
        };
        var productSpec = new ProductSpecSingleResult(filter);
        var productToUpdate = await _repository.GetBySpecAsync(productSpec, cancellationToken);
        if (productToUpdate == null) throw new ProductNotFoundException(request.ProductId);

        var productWarrantyToRemove = productToUpdate.ProductWarranties
            .ToList().Where(productWarranty => request.ProductWarranties != null &&
                                               !request.ProductWarranties.Contains(productWarranty.WarrantyId))
            .ToList();
        productToUpdate.RemoveProductWarranties(productWarrantyToRemove);

        var productWarrantyToAdd = new List<PackageEntity.ProductWarranty>();
        
        var requestProductWarranties = request.ProductWarranties?.ToList();
        
        foreach (var (warrantyId, elementToUpdate) in from warrantyId in requestProductWarranties
                 let elementToUpdate = productToUpdate.ProductWarranties.FirstOrDefault(x => x.WarrantyId == warrantyId)
                 select (warrantyId, elementToUpdate))
            switch (elementToUpdate)
            {
                case null:
                {
                    var pw = new PackageEntity.ProductWarranty
                    {
                        ProductId = request.ProductId,
                        WarrantyId = warrantyId
                    };
                    productWarrantyToAdd.Add(pw);
                    break;
                }

                default:
                    elementToUpdate.IsDeleted = false;
                    break;
            }

        productToUpdate.AddProductWarranties(productWarrantyToAdd);
        productToUpdate.ReorderProductWarranties();
        await _repository.UpdateAsync(productToUpdate, cancellationToken);

        return Unit.Value;
    }
}