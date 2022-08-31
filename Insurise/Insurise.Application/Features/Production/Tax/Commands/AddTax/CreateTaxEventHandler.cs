using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Tax.Commands.AddTax;

public class CreateTaxEventHandler : IRequestHandler<CreateTaxCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Core.Entities.Production.WarrantyAggregate.Tax> _taxRepository;

    public CreateTaxEventHandler(IMapper mapper,
        IRepository<Core.Entities.Production.WarrantyAggregate.Tax> taxRepository)
    {
        _mapper = mapper;
        _taxRepository = taxRepository;
    }

    public async Task<int> Handle(CreateTaxCommand request, CancellationToken cancellationToken)
    {
        var tax = _mapper.Map<Core.Entities.Production.WarrantyAggregate.Tax>(request);
        tax = await _taxRepository.AddAsync(tax, cancellationToken);

        return tax.Id;
    }
}