using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Status.Commands.UpdateStatus;

public class UpdateStatusEventHandler : IRequestHandler<UpdateStatusCommand>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Status> _statusRepository;
    private readonly IMapper _mapper;

    public UpdateStatusEventHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Status> statusRepository)
    {
        _mapper = mapper;
        _statusRepository = statusRepository;
    }

    public async Task<Unit> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
    {
        var statusToUpdate = await _statusRepository.GetByIdAsync(request.StatusId, cancellationToken);

        if (statusToUpdate == null) throw new StatusNotFoundException(request.StatusId);

        _mapper.Map(request, statusToUpdate, typeof(UpdateStatusCommand),
            typeof(Core.Entities.Sinister.SinisterAggregate.Status));

        await _statusRepository.UpdateAsync(statusToUpdate, cancellationToken);

        return Unit.Value;
    }
}