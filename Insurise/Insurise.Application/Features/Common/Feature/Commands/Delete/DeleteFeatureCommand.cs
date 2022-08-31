using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.Delete;

public class DeleteFeatureCommand : IRequest
{
    public DeleteFeatureCommand(int featureId)
    {
        FeatureId = featureId;
    }

    public int FeatureId { get; }
}