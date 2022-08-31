using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;

public class GetWarrantiesListQueryHandler : IRequestHandler<GetWarrantiesListQuery, List<WarrantyDto>>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Warranty> _warrantyRepository;

    public GetWarrantiesListQueryHandler(IMapper mapper, IRepository<Warranty> warrantyRepository)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<List<WarrantyDto>> Handle(GetWarrantiesListQuery request, CancellationToken cancellationToken)
    {
        var all = await _warrantyRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<WarrantyDto>>(all);
    }
}