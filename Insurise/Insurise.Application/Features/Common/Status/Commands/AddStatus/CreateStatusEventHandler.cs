using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Status.Commands.AddStatus;

public class CreateStatusEventHandler : IRequestHandler<CreateStatusCommand, int>
{
    private readonly IRepository<Core.Entities.Sinister.SinisterAggregate.Status> _statusRepository;
    private readonly IMapper _mapper;

    public CreateStatusEventHandler(IMapper mapper,
        IRepository<Core.Entities.Sinister.SinisterAggregate.Status> statusRepository)
    {
        _mapper = mapper;
        _statusRepository = statusRepository;
    }

    public async Task<int> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        var status = _mapper.Map<Core.Entities.Sinister.SinisterAggregate.Status>(request);
        status = await _statusRepository.AddAsync(status, cancellationToken);

        return status.Id;
    }
}