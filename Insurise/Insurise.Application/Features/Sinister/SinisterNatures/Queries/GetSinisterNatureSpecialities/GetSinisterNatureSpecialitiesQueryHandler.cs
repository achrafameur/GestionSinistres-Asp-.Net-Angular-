using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatures;
using Insurise.SharedKernel.Interfaces;
using MediatR;


namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureSpecialities;

public class GetSinisterNatureSpecialitiesQueryHandler : IRequestHandler<GetSinisterNatureSpecialitiesQuery,
    List<GetSinisterNatureSpecialitiesDto>>
{
    private readonly IRepository<SinisterNature> _SinisterNatureSpecialityRepository;
    private readonly IMapper _mapper;

    public GetSinisterNatureSpecialitiesQueryHandler(IMapper mapper,
        IRepository<SinisterNature> SinisterNatureSpecialityRepository)
    {
        _mapper = mapper;
        _SinisterNatureSpecialityRepository = SinisterNatureSpecialityRepository;
    }

    public async Task<List<GetSinisterNatureSpecialitiesDto>> Handle(GetSinisterNatureSpecialitiesQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new SinisterNatureFilter
        {
            SinisterNatureId = request.SinisterNatureId,
            LoadChildren = true,
            Children = new List<string> { "SinisterNaturesSpecialities", "SinisterNaturesSpecialities.ChainElement" },
            IsPagingEnabled = true
        };

        var specialitiesBySinisterNatureIdSpec = new SinisterNatureSpecSingleResult(filter);
        var specialitiesPerSinisterNature =
            await _SinisterNatureSpecialityRepository.GetBySpecAsync(specialitiesBySinisterNatureIdSpec);
        return _mapper.Map<List<GetSinisterNatureSpecialitiesDto>>(
            specialitiesPerSinisterNature?.SinisterNaturesSpecialities.OrderBy(x => x.SinisterNature));
    }
}