using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters.Commun.features;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Feature.Commands.SetItemsFeatures;

public class SetFeaturesItemsCommandHandler : IRequestHandler<SetFeaturesItemsCommand>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;

    public SetFeaturesItemsCommandHandler(IRepository<Core.Entities.Common.Feature> featureRepository)
    {
        _featureRepository = featureRepository;
    }

    public async Task<Unit> Handle(SetFeaturesItemsCommand request, CancellationToken cancellationToken)
    {
        var filter = new FeatureFilter
        {
            FeatureId = request.FeatureId,
            LoadChildren = true,
            Children = new List<string> {"FeatureItems"},
            IsPagingEnabled = false
        };
        var featureSpec = new FeatureSpecSingleResult(filter);
        var featureToUpdate = await _featureRepository.GetBySpecAsync(featureSpec, cancellationToken);
        if (featureToUpdate == null) throw new FeatureNotFoundException(request.FeatureId);

        var featureItemToRemove = featureToUpdate.FeatureItems.ToList().Where(featureItem =>
            request.FeatureItems != null && !request.FeatureItems.Contains(featureItem.FeatureId)).ToList();
        featureToUpdate.RemoveFeatureItems(featureItemToRemove);
        var featureItemToAdd = new List<FeatureItem>();
        if (request.FeatureItems != null)
        {
            var listRequestFeatureItems = request.FeatureItems.ToList();
            foreach (var itemId in listRequestFeatureItems)
            {
                var elementToUpdate = featureToUpdate.FeatureItems.FirstOrDefault(x => x.ItemId == itemId);
                if (elementToUpdate == null)
                {
                    var fi = new FeatureItem
                    {
                        FeatureId = request.FeatureId,
                        ItemId = itemId
                    };
                    featureItemToAdd.Add(fi);
                }
                else
                {
                    elementToUpdate.IsDeleted = false;
                }
            }
        }

        featureToUpdate.AddFeatureItems(featureItemToAdd);
        featureToUpdate.ReorderFeatureItems();
        await _featureRepository.UpdateAsync(featureToUpdate, cancellationToken);

        return Unit.Value;
    }
}