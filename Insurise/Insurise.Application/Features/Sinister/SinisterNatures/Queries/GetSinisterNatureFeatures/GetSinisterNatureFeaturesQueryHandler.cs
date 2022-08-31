using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatures;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureFeatures;

public class
    GetSinisterNatureFeaturesQueryHandler : IRequestHandler<GetSinisterNatureFeaturesQuery,
        List<GetSinisterNatureFeaturesDto>>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public GetSinisterNatureFeaturesQueryHandler(IMapper mapper, IRepository<SinisterNature> SinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = SinisterNatureRepository;
    }

    public async Task<List<GetSinisterNatureFeaturesDto>> Handle(GetSinisterNatureFeaturesQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new SinisterNatureFilter
        {
            SinisterNatureId = request.SinisterNatureId,
            LoadChildren = true,
            Children = new List<string> {"SinisterNaturesFeatures", "SinisterNaturesFeatures.Feature"},
            IsPagingEnabled = true
        };

        var featuresBySinisterNatureIdSpec = new SinisterNatureSpecSingleResult(filter);
        var featuresPerSinisterNature = await _SinisterNatureRepository.GetBySpecAsync(featuresBySinisterNatureIdSpec);
        return _mapper.Map<List<GetSinisterNatureFeaturesDto>>(
            featuresPerSinisterNature?.sinisterNaturesFeatures.OrderBy(x => x.SinisterNature));
    }
}