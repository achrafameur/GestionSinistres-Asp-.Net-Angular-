using AutoMapper;
using Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Durations.Queries.GetDurationsList;

public class GetDurationListQueryHandler : IRequestHandler<GetDurationListQuery, List<DurationDetailDto>>
{
    private readonly IRepository<Duration> _durationRepository;
    private readonly IMapper _mapper;

    public GetDurationListQueryHandler(IMapper mapper, IRepository<Duration> durationRepository)
    {
        _mapper = mapper;
        _durationRepository = durationRepository;
    }

    public async Task<List<DurationDetailDto>> Handle(GetDurationListQuery request,
        CancellationToken cancellationToken)
    {
        var allDurations = await _durationRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<DurationDetailDto>>(allDurations);
    }
}