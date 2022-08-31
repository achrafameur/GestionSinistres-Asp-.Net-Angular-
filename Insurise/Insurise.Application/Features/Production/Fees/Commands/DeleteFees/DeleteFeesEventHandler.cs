using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Production.Fees.Commands.DeleteFees;

public class DeleteFeesEventHandler : IRequestHandler<DeleteFeesCommand>
{
    private readonly IRepository<Fee> _feesRepository;

    public DeleteFeesEventHandler(IRepository<Fee> feesRepository)
    {
        _feesRepository = feesRepository;
    }

    public async Task<Unit> Handle(DeleteFeesCommand request, CancellationToken cancellationToken)
    {
        var feeToDelete = await _feesRepository.GetByIdAsync(request.feesId, cancellationToken);

        if (feeToDelete == null) throw new FeeNotFoundException(request.feesId);

        await _feesRepository.DeleteAsync(feeToDelete, cancellationToken);

        return Unit.Value;
    }
}