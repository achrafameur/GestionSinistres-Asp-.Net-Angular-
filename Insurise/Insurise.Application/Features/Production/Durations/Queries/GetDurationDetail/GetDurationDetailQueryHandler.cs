using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;

public class GetDurationDetailQueryHandler : IRequestHandler<GetDurationDetailQuery, DurationDetailDto>
{
    private readonly IRepository<Duration> _durationRepository;
    private readonly IMapper _mapper;

    public GetDurationDetailQueryHandler(IMapper mapper, IRepository<Duration> durationRepository)
    {
        _mapper = mapper;
        _durationRepository = durationRepository;
    }

    public async Task<DurationDetailDto> Handle(GetDurationDetailQuery request, CancellationToken cancellationToken)
    {
        var duration = await _durationRepository.GetByIdAsync(request.DurationId, cancellationToken);
        var returnedDuration = _mapper.Map<DurationDetailDto>(duration);

        return returnedDuration;
    }
}