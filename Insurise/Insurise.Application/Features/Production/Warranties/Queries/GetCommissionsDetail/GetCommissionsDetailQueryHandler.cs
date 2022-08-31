using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Production.Warranties;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetCommissionsDetail;

public class GetCommissionsDetailQueryHandler : IRequestHandler<GetCommissionsDetailQuery, List<WarrantyCommissionDto>>
{
    private readonly IRepository<Warranty> _warrantyRepository;
    private readonly IMapper _mapper;

    public GetCommissionsDetailQueryHandler(IRepository<Warranty> warrantyRepository, IMapper mapper)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<List<WarrantyCommissionDto>> Handle(GetCommissionsDetailQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new WarrantyFilter
        {
            WarrantyId = request.WarrantyId,
            LoadChildren = true,
            Children = new List<string> {"WarrantyCommissions", "WarrantyCommissions.Commission"},
            IsPagingEnabled = false
        };
        var commissionsByWarrantyIdSpec = new WarrantySpecSingleResult(filter);


        var commissionsByWarranty =
            await _warrantyRepository.GetBySpecAsync(commissionsByWarrantyIdSpec, cancellationToken);
        var mappedWarranty =
            _mapper.Map<List<WarrantyCommissionDto>>(
                commissionsByWarranty?.WarrantyCommissions.OrderBy(x => x.WarrantyId));
        return mappedWarranty;
    }
}