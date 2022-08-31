using AutoMapper;
using Insurise.Core.Specifications.Filters.Commun.features;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Production.Feature;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Queries.GetItemsDetail;

public class GetItemsDetailQueryHandler : IRequestHandler<GetItemsDetailQuery, List<FeatureItemDto>>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;
    private readonly IMapper _mapper;

    public GetItemsDetailQueryHandler(IRepository<Core.Entities.Common.Feature> featureRepository, IMapper mapper)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<List<FeatureItemDto>> Handle(GetItemsDetailQuery request, CancellationToken cancellationToken)
    {
        var filter = new FeatureFilter
        {
            FeatureId = request.FeatureId,
            LoadChildren = true,
            Children = new List<string> {"FeatureItems", "FeatureItems.Item"},
            IsPagingEnabled = false
        };
        var itemsByFeatureIdSpec = new FeatureSpecSingleResult(filter);


        var itemsByFeature = await _featureRepository.GetBySpecAsync(itemsByFeatureIdSpec, cancellationToken);
        var mappedFeature = _mapper.Map<List<FeatureItemDto>>(itemsByFeature?.FeatureItems.OrderBy(x => x.Rank));
        return mappedFeature;
    }
}