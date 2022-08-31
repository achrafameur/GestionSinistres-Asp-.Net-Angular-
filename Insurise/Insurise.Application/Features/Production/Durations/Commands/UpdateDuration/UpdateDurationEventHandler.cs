using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Production.Durations.Commands.UpdateDuration;

public class UpdateDurationEventHandler : IRequestHandler<UpdateDurationCommand>
{
    private readonly IRepository<Duration> _durationRepository;
    private readonly IMapper _mapper;

    public UpdateDurationEventHandler(IMapper mapper, IRepository<Duration> durationRepository)
    {
        _mapper = mapper;
        _durationRepository = durationRepository;
    }

    public async Task<Unit> Handle(UpdateDurationCommand request, CancellationToken cancellationToken)
    {
        var durationToUpdate = await _durationRepository.GetByIdAsync(request.DurationId, cancellationToken);

        if (durationToUpdate == null) throw new DurationNotFoundException(request.DurationId);

        _mapper.Map(request, durationToUpdate, typeof(UpdateDurationCommand), typeof(Duration));

        await _durationRepository.UpdateAsync(durationToUpdate, cancellationToken);

        return Unit.Value;
    }
}