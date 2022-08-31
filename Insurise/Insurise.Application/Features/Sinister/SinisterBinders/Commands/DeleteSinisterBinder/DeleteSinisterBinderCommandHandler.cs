using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterBinders.Commands.DeleteSinisterBinder;

public class DeleteSinisterBinderCommandHandler : IRequestHandler<DeleteSinisterBinderCommand>
{
    private readonly IRepository<SinisterBinder> _sinisterBinderRepository;
    private readonly IMapper _mapper;

    public DeleteSinisterBinderCommandHandler(IMapper mapper, IRepository<SinisterBinder> sinisterBinderRepository)
    {
        _mapper = mapper;
        _sinisterBinderRepository = sinisterBinderRepository;
    }

    public async Task<Unit> Handle(DeleteSinisterBinderCommand request, CancellationToken cancellationToken)
    {
        var sinisterBinderToDelete =
            await _sinisterBinderRepository.GetByIdAsync(request.SinisterBinderId, cancellationToken);

        // if (sinisterBinderToDelete == null) throw new NotFoundException("Sinister Binder", request.SinisterBinderId);

        await _sinisterBinderRepository.DeleteAsync(sinisterBinderToDelete, cancellationToken);

        return Unit.Value;
    }
}