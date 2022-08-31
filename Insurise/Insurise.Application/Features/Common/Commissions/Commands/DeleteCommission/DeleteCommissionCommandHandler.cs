using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Commissions.Commands.DeleteCommission;

public class DeleteCommissionCommandHandler : IRequestHandler<DeleteCommissionCommand>
{
    private readonly IRepository<Commission> _commissionRepository;

    public DeleteCommissionCommandHandler(IRepository<Commission> commissionRepository)
    {
        _commissionRepository = commissionRepository;
    }

    public async Task<Unit> Handle(DeleteCommissionCommand request, CancellationToken cancellationToken)
    {
        var commissionToDelete = await _commissionRepository.GetByIdAsync(request.CommissionId, cancellationToken);
        if (commissionToDelete == null) throw new CommissionNotFoundException(request.CommissionId);

        await _commissionRepository.DeleteAsync(commissionToDelete, cancellationToken);
        return Unit.Value;
    }
}