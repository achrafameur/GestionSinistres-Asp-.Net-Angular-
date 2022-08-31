using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Tax.Commands.UpdateTax;

public class UpdateTaxEventHandler : IRequestHandler<UpdateTaxCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Core.Entities.Production.WarrantyAggregate.Tax> _taxRepository;

    public UpdateTaxEventHandler(IMapper mapper,
        IRepository<Core.Entities.Production.WarrantyAggregate.Tax> taxRepository)
    {
        _mapper = mapper;
        _taxRepository = taxRepository;
    }

    public async Task<Unit> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
    {
        var taxToUpdate = await _taxRepository.GetByIdAsync(request.TaxId, cancellationToken);

        if (taxToUpdate == null) throw new TaxNotFoundException(request.TaxId);

        _mapper.Map(request, taxToUpdate, typeof(UpdateTaxCommand),
            typeof(Core.Entities.Production.WarrantyAggregate.Tax));

        await _taxRepository.UpdateAsync(taxToUpdate, cancellationToken);

        return Unit.Value;
    }
}