using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.Delete;

public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;

    public DeleteFeatureCommandHandler(IRepository<Core.Entities.Common.Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<Unit> Handle(DeleteFeatureCommand command, CancellationToken cancellationToken)
    {
        var featureToDelete =
            await _featureRepository.GetByIdAsync(command.FeatureId, cancellationToken);
        if (featureToDelete == null) throw new FeatureNotFoundException(command.FeatureId);
        await _featureRepository.DeleteAsync(featureToDelete, cancellationToken);
        return Unit.Value;
    }
}