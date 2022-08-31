using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.SetItemsFeatures;

public class SetFeaturesItemsCommand : IRequest
{
    public int FeatureId { get; set; }

    public ICollection<int>? FeatureItems { get; set; }
}