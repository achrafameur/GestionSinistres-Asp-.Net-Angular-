using AutoMapper;
using Insurise.Application.Features.Common.Feature.Queries.GetList;
using Insurise.Core.Specifications.Filters.Commun.features;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Queries.GetDetail;

public class GetFeatureDetailQueryHandler : IRequestHandler<GetFeatureDetailQuery, FeatureDto>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;
    private readonly IMapper _mapper;

    public GetFeatureDetailQueryHandler(IMapper mapper, IRepository<Core.Entities.Common.Feature> featureRepository)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<FeatureDto> Handle(GetFeatureDetailQuery request,
        CancellationToken cancellationToken)
    {
        var customerByFeatureIdSpec = new FeatureByIdSpec(request.FeatureId);
        var feature = await _featureRepository.GetBySpecAsync(customerByFeatureIdSpec);
        var returnedFeature = _mapper.Map<FeatureDto>(feature);
        return returnedFeature;
    }
}