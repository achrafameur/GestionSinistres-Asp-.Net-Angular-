using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarranty;

public class DeleteWarrantyCommandHandler : IRequestHandler<DeleteWarrantyCommand>
{
    private readonly IRepository<Warranty> _warrantyRepository;

    public DeleteWarrantyCommandHandler(IRepository<Warranty> warrantyRepository)
    {
        _warrantyRepository = warrantyRepository;
    }

    public async Task<Unit> Handle(DeleteWarrantyCommand request, CancellationToken cancellationToken)
    {
        var warrantyToDelete = await _warrantyRepository.GetByIdAsync(request.WarrantyId, cancellationToken);
        if (warrantyToDelete == null) throw new WarrantyNotFoundException(request.WarrantyId);
        await _warrantyRepository.DeleteAsync(warrantyToDelete, cancellationToken);
        return Unit.Value;
    }
}