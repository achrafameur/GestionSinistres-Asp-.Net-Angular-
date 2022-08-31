using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using InsuriseDTO.Production.Warranties;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetFeaturesDetail;

public class GetFeaturesDetailQueryHandler : IRequestHandler<GetFeaturesDetailQuery, List<WarrantyFeatureDto>>
{
    private readonly IRepository<Warranty> _warrantyRepository;
    private readonly IMapper _mapper;

    public GetFeaturesDetailQueryHandler(IRepository<Warranty> warrantyRepository, IMapper mapper)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<List<WarrantyFeatureDto>> Handle(GetFeaturesDetailQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new WarrantyFilter
        {
            WarrantyId = request.WarrantyId,
            LoadChildren = true,
            Children = new List<string> {"WarrantyFeatures", "WarrantyFeatures.Feature"},
            IsPagingEnabled = false
        };
        var featuresByWarrantyIdSpec = new WarrantySpecSingleResult(filter);


        var featuresByWarranty = await _warrantyRepository.GetBySpecAsync(featuresByWarrantyIdSpec);
        var mappedWarranty =
            _mapper.Map<List<WarrantyFeatureDto>>(featuresByWarranty?.WarrantyFeatures.OrderBy(x => x.Rank));
        return mappedWarranty;
    }
}