using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.Experts;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.Experts.Queries.GetExpertSpecialities;

public class GetExpertSpecialitiesQueryHandler : IRequestHandler<GetExpertSpecialitiesQuery, List<GetExpertSpecialityDto>>
{
    private readonly IRepository<Expert> _expertSpecialityRepository;
    private readonly IMapper _mapper;

    public GetExpertSpecialitiesQueryHandler(IMapper mapper, IRepository<Expert> expertSpecialityRepository)
    {
        _mapper = mapper;
        _expertSpecialityRepository = expertSpecialityRepository;
    }

    public async Task<List<GetExpertSpecialityDto>> Handle(GetExpertSpecialitiesQuery request,
        CancellationToken cancellationToken)
    {
        var filter = new ExpertFilter
        {
            ExpertId = request.ExpertId,
            LoadChildren = true,
            Children = new List<string> { "ExpertSpecialities", "ExpertSpecialities.ChainElement" },
            IsPagingEnabled = true
        };

        var specialitiesByExpertIdSpec = new ExpertSpecSingleResult(filter);
        var specialitiesPerExpert =
            await _expertSpecialityRepository.GetBySpecAsync(specialitiesByExpertIdSpec);
        return _mapper.Map<List<GetExpertSpecialityDto>>(
            specialitiesPerExpert?.ExpertSpecialities.OrderBy(x => x.Expert));
    }
}