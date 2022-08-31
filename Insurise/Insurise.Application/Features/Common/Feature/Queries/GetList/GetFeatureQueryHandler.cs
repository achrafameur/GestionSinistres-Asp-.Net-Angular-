using AutoMapper;
using Insurise.Application.Features.Common.Feature.Queries.GetList;
using Insurise.Core.Specifications.Filters.Commun.features;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Queries.GetList;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureListQuery, List<FeatureDto>>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;

    private readonly IMapper _mapper;

    public GetFeatureQueryHandler(IMapper mapper, IRepository<Core.Entities.Common.Feature> featureRepository)
    {
        _mapper = mapper;
        _featureRepository = featureRepository;
    }

    public async Task<List<FeatureDto>> Handle(GetFeatureListQuery request, CancellationToken cancellationToken)
    {
        var filter = new FeatureFilter
        {
            LoadChildren = true,
            Children = new List<string> {"Nature", "Chain"},
            IsPagingEnabled = false
        };
        var spec = new FeatureSpec(filter);
        var allFeatures = await _featureRepository.ListAsync(spec, cancellationToken);
        var mappedFeature = _mapper.Map<List<FeatureDto>>(allFeatures);
        return mappedFeature;
    }
}