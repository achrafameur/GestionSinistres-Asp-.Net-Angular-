using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyCommission;

public class DeleteWarrantyCommissionCommandHandler : IRequestHandler<DeleteWarrantyCommissionCommand>
{
    private readonly IRepository<WarrantyCommission> _warrantyCommissionRepository;

    public DeleteWarrantyCommissionCommandHandler(IRepository<WarrantyCommission> warrantyCommissionRepository)
    {
        _warrantyCommissionRepository = warrantyCommissionRepository;
    }

    public async Task<Unit> Handle(DeleteWarrantyCommissionCommand request, CancellationToken cancellationToken)
    {
        var warrantyCommissionToDelete =
            await _warrantyCommissionRepository.GetByIdAsync(request.Id, cancellationToken);
        if (warrantyCommissionToDelete == null) throw new WarrantyCommissionNotFoundException(request.Id);
        warrantyCommissionToDelete.IsDeleted = true;
        await _warrantyCommissionRepository.UpdateAsync(warrantyCommissionToDelete, cancellationToken);

        return Unit.Value;
    }
}