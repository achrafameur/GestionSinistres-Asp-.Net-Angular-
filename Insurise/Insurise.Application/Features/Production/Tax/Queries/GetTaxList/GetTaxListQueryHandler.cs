using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Tax.Queries.GetTaxList;

public class GetTaxListQueryHandler : IRequestHandler<GetTaxListQuery, List<TaxDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Core.Entities.Production.WarrantyAggregate.Tax> _taxRepository;

    public GetTaxListQueryHandler(IMapper mapper,
        IRepository<Core.Entities.Production.WarrantyAggregate.Tax> taxRepository)
    {
        _mapper = mapper;
        _taxRepository = taxRepository;
    }

    public async Task<List<TaxDto>> Handle(GetTaxListQuery request, CancellationToken cancellationToken)
    {
        var allTaxes = await _taxRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<TaxDto>>(allTaxes);
    }
}