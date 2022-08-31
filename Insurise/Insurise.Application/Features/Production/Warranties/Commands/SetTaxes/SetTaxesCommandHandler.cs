using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.SetTaxes;

public class SetTaxesCommandHandler : IRequestHandler<SetTaxesCommand>
{
    private readonly IRepository<Warranty> _warrantyRepository;

    public SetTaxesCommandHandler(IRepository<Warranty> warrantyRepository)
    {
        _warrantyRepository = warrantyRepository;
    }

    public async Task<Unit> Handle(SetTaxesCommand request, CancellationToken cancellationToken)
    {
        var filter = new WarrantyFilter
        {
            WarrantyId = request.WarrantyId,
            LoadChildren = true,
            Children = new List<string> {"WarrantyTaxes"},
            IsPagingEnabled = false
        };
        var warrantySpec = new WarrantySpecSingleResult(filter);
        var warrantyToUpdate = await _warrantyRepository.GetBySpecAsync(warrantySpec, cancellationToken);
        if (warrantyToUpdate == null) throw new WarrantyNotFoundException(request.WarrantyId);

        var warrantyTaxToRemove = new List<WarrantyTax>();
        foreach (var warrantyTax in warrantyToUpdate.WarrantyTaxes.ToList())
            if (request.WarrantyTaxes != null && !request.WarrantyTaxes.Contains(warrantyTax.TaxId))
                warrantyTaxToRemove.Add(warrantyTax);
        warrantyToUpdate.RemoveWarrantyTaxes(warrantyTaxToRemove);

        var warrantyTaxToAdd = new List<WarrantyTax>();

        var listRequestWarrantyTaxes = request.WarrantyTaxes.ToList();

        foreach (var taxId in listRequestWarrantyTaxes)
        {
            var elementToUpdate = warrantyToUpdate.WarrantyTaxes.FirstOrDefault(x => x.TaxId == taxId);
            if (elementToUpdate == null)
            {
                var wt = new WarrantyTax
                {
                    WarrantyId = request.WarrantyId,
                    TaxId = taxId
                };
                warrantyTaxToAdd.Add(wt);
            }
            else
            {
                elementToUpdate.IsDeleted = false;
            }
        }

        warrantyToUpdate.AddWarrantyTaxes(warrantyTaxToAdd);
        warrantyToUpdate.ReorderWarrantyTaxes();
        await _warrantyRepository.UpdateAsync(warrantyToUpdate, cancellationToken);

        return Unit.Value;
    }
}
