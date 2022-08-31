using AutoMapper;
using Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesDetails;

public class GetWarrantiesDetailsQueryHandler : IRequestHandler<GetWarrantiesDetailsQuery, WarrantyDto>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Warranty> _warrantyRepository;

    public GetWarrantiesDetailsQueryHandler(IMapper mapper, IRepository<Warranty> warrantyRepository)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<WarrantyDto> Handle(GetWarrantiesDetailsQuery request, CancellationToken cancellationToken)
    {
        var warranty = await _warrantyRepository.GetByIdAsync(request.WarrantyId, cancellationToken);
        var dto = _mapper.Map<WarrantyDto>(warranty);
        return dto;
    }
}