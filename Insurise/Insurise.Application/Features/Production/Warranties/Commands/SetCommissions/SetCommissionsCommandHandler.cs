using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.SetCommissions;

public class SetCommissionsCommandHandler : IRequestHandler<SetCommissionsCommand>
{
    private readonly IRepository<Warranty> _warrantyRepository;

    public SetCommissionsCommandHandler(IRepository<Warranty> warrantyRepository)
    {
        _warrantyRepository = warrantyRepository; 
    }

    public async Task<Unit> Handle(SetCommissionsCommand request, CancellationToken cancellationToken)
    {
        var filter = new WarrantyFilter
        {
            WarrantyId = request.WarrantyId,
            LoadChildren = true,
            Children = new List<string> {"WarrantyCommissions"},
            IsPagingEnabled = false
        };
        var warrantySpec = new WarrantySpecSingleResult(filter);
        var warrantyToUpdate = await _warrantyRepository.GetBySpecAsync(warrantySpec, cancellationToken);
        if (warrantyToUpdate == null) throw new WarrantyNotFoundException(request.WarrantyId);

        var warrantyCommissionToRemove = warrantyToUpdate.WarrantyCommissions
            .ToList().Where(warrantyCommission => request.WarrantyCommissions != null &&
                                                  !request.WarrantyCommissions.Contains(warrantyCommission
                                                      .CommissionId))
            .ToList();

        warrantyToUpdate.RemoveWarrantyCommissions(warrantyCommissionToRemove);

        var warrantyCommissionToAdd = new List<WarrantyCommission>();
        var listRequestWarrantyCommissions = request.WarrantyCommissions.ToList();

        foreach (var commissionId in listRequestWarrantyCommissions)
        {
            var elementToUpdate =
                warrantyToUpdate.WarrantyCommissions.FirstOrDefault(x => x.CommissionId == commissionId);
            if (elementToUpdate == null)
            {
                var wc = new WarrantyCommission
                {
                    WarrantyId = request.WarrantyId,
                    CommissionId = commissionId
                };
                warrantyCommissionToAdd.Add(wc);
            }
            else
            {
                elementToUpdate.IsDeleted = false;
            }
        }

        warrantyToUpdate.AddWarrantyCommissions(warrantyCommissionToAdd);
        warrantyToUpdate.ReorderWarrantyCommissions();
        await _warrantyRepository.UpdateAsync(warrantyToUpdate, cancellationToken);

        return Unit.Value;
    }
}