using AutoMapper;
using Insurise.Application.Features.Production.Tax.Queries.GetTaxList;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Tax.Queries.GetTaxDetail;

public class GetTaxDetailQueryHandler : IRequestHandler<GetTaxDetailQuery, TaxDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Core.Entities.Production.WarrantyAggregate.Tax> _taxRepository;

    public GetTaxDetailQueryHandler(IMapper mapper,
        IRepository<Core.Entities.Production.WarrantyAggregate.Tax> taxRepository)
    {
        _mapper = mapper;
        _taxRepository = taxRepository;
    }

    public async Task<TaxDto> Handle(GetTaxDetailQuery request, CancellationToken cancellationToken)
    {
        var tax = await _taxRepository.GetByIdAsync(request.TaxId, cancellationToken);
        var dto = _mapper.Map<TaxDto>(tax);
        return dto;
    }
}