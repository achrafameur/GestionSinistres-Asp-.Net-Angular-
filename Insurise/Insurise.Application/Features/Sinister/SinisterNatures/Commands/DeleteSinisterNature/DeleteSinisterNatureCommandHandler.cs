using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.DeleteSinisterNature;

public class DeleteSinisterNatureCommandHandler : IRequestHandler<DeleteSinisterNatureCommand>
{
    private readonly IRepository<SinisterNature> _sinisterNatureRepository;

    public DeleteSinisterNatureCommandHandler(IRepository<SinisterNature> sinisterNatureRepository)
    {
        _sinisterNatureRepository = sinisterNatureRepository;
    }

    public async Task<Unit> Handle(DeleteSinisterNatureCommand request, CancellationToken cancellationToken)
    {
        var sinisterNatureToDelete =
            await _sinisterNatureRepository.GetByIdAsync(request.SinisterNatureId, cancellationToken);

        if (sinisterNatureToDelete == null) throw new SinisterNatureNotFoundException(request.SinisterNatureId);

        await _sinisterNatureRepository.DeleteAsync(sinisterNatureToDelete, cancellationToken);

        return Unit.Value;
    }
}