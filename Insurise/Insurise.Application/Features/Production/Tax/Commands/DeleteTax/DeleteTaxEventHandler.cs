using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Tax.Commands.DeleteTax;

public class DeleteTaxEventHandler : IRequestHandler<DeleteTaxCommand>
{
    private readonly IRepository<Core.Entities.Production.WarrantyAggregate.Tax> _taxRepository;

    public DeleteTaxEventHandler(IRepository<Core.Entities.Production.WarrantyAggregate.Tax> taxRepository)
    {
        _taxRepository = taxRepository;
    }

    public async Task<Unit> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
    {
        var taxToDelete = await _taxRepository.GetByIdAsync(request.TaxId, cancellationToken);

        if (taxToDelete == null) throw new TaxNotFoundException(request.TaxId);

        await _taxRepository.DeleteAsync(taxToDelete, cancellationToken);

        return Unit.Value;
    }
}