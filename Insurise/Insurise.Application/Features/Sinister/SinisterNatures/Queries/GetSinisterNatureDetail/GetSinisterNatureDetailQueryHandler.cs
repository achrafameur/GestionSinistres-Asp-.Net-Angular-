using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.Core.Specifications.Filters.Sinister.SinisterNatures;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;

public class GetSinisterNatureDetailQueryHandler : IRequestHandler<GetSinisterNatureDetailQuery, SinisterNatureDto>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public GetSinisterNatureDetailQueryHandler(IMapper mapper, IRepository<SinisterNature> sinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = sinisterNatureRepository;
    }

    public async Task<SinisterNatureDto> Handle(GetSinisterNatureDetailQuery request,
        CancellationToken cancellationToken)
    {
        var sinisterNatureIdSpec = new SinisterNatureByIdSpec(request.Id);

        var sinisterNature = await _SinisterNatureRepository.GetBySpecAsync(sinisterNatureIdSpec);
        var returnedSinisterNature = _mapper.Map<SinisterNatureDto>(sinisterNature);

        return returnedSinisterNature;
    }
}