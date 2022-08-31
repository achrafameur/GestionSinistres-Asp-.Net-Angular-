using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Status.Commands.DeleteStatus;

public class DeleteStatusEventHandler : IRequestHandler<DeleteStatusCommand>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Status> _statusRepository;

    public DeleteStatusEventHandler(IRepository<Core.Entities.Sinister.SinisterAggregate.Status> statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public async Task<Unit> Handle(DeleteStatusCommand request, CancellationToken cancellationToken)
    {
        var statusToDelete = await _statusRepository.GetByIdAsync(request.StatusId, cancellationToken);

        if (statusToDelete == null) throw new StatusNotFoundException(request.StatusId);

        await _statusRepository.DeleteAsync(statusToDelete, cancellationToken);

        return Unit.Value;
    }
}