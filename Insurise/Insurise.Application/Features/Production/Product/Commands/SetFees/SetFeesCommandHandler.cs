using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using PackageEntity = Insurise.Core.Entities.Production.ProductAggregate;


namespace Insurise.Application.Features.Production.Product.Commands.SetFees;

public class SetFeesCommandHandler : IRequestHandler<SetFeesCommand>
{
    private readonly IRepository<PackageEntity.Product> _repository;

    public SetFeesCommandHandler(IRepository<PackageEntity.Product> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(SetFeesCommand request, CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> {"ProductFees"},
            IsPagingEnabled = false
        };
        var productSpec = new ProductSpecSingleResult(filter);
        var productToUpdate = await _repository.GetBySpecAsync(productSpec, cancellationToken);
        if (productToUpdate == null) throw new ProductNotFoundException(request.ProductId);

        var productFeesToRemove = productToUpdate.ProductFees
            .ToList()
            .Where(productFees => request.ProductFees != null && !request.ProductFees.Contains(productFees.FeeId))
            .ToList();
        productToUpdate.RemoveProductFees(productFeesToRemove);
        var productFeeToAdd = new List<PackageEntity.ProductFee>();
        var requestProductWarranties = request.ProductFees.ToList();
        foreach (var feesId in requestProductWarranties)
        {
            var elementToUpdate = productToUpdate.ProductFees.FirstOrDefault(x => x.FeeId == feesId);
            if (elementToUpdate == null)
            {
                var pw = new PackageEntity.ProductFee
                {
                    ProductId = request.ProductId,
                    FeeId = feesId
                };
                productFeeToAdd.Add(pw);
            }
            else
            {
                elementToUpdate.IsDeleted = false;
            }
        }

        productToUpdate.AddProductFees(productFeeToAdd);
        productToUpdate.ReorderProductFees();
        await _repository.UpdateAsync(productToUpdate, cancellationToken);

        return Unit.Value;
    }
}
