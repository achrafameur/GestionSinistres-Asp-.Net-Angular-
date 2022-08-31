using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Durations.Commands.AddDuration;

public class CreateDurationEventHandler : IRequestHandler<CreateDurationCommand, int>
{
    private readonly IRepository<Duration> _durationRepository;
    private readonly IMapper _mapper;

    public CreateDurationEventHandler(IMapper mapper, IRepository<Duration> durationRepository)
    {
        _mapper = mapper;
        _durationRepository = durationRepository;
    }

    public async Task<int> Handle(CreateDurationCommand request, CancellationToken cancellationToken)
    {
        var duration = _mapper.Map<Duration>(request);
        @duration = await _durationRepository.AddAsync(duration, cancellationToken);
        return @duration.Id;
    }
}