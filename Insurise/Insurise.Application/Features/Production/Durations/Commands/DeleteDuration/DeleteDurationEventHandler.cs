using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Production.Durations.Commands.DeleteDuration;

public class DeleteDurationEventHandler : IRequestHandler<DeleteDurationCommand>
{
    private readonly IRepository<Duration> _durationRepository;

    public DeleteDurationEventHandler(IRepository<Duration> durationRepository)
    {
        _durationRepository = durationRepository;
    }

    public async Task<Unit> Handle(DeleteDurationCommand request, CancellationToken cancellationToken)
    {
        var durationToDelete = await _durationRepository.GetByIdAsync(request.DurationId, cancellationToken);

        if (durationToDelete == null) throw new DurationNotFoundException(request.DurationId);

        await _durationRepository.DeleteAsync(durationToDelete, cancellationToken);
        return Unit.Value;
    }
}