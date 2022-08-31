using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.SetFeatures;

public class SetFeaturesCommandHandler : IRequestHandler<SetFeaturesToWarrantyCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Warranty> _warrantyRepository;

    public SetFeaturesCommandHandler(IRepository<Warranty> warrantyRepository, IMapper mapper)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<Unit> Handle(SetFeaturesToWarrantyCommand request, CancellationToken cancellationToken)
    {
        var filter = new WarrantyFilter
        {
            WarrantyId = request.WarrantyId,
            LoadChildren = true,
            Children = new List<string> {"WarrantyFeatures"},
            IsPagingEnabled = false
        };
        var warrantySpec = new WarrantySpecSingleResult(filter);
        var warrantyToUpdate = await _warrantyRepository.GetBySpecAsync(warrantySpec, cancellationToken);
        if (warrantyToUpdate == null) throw new WarrantyNotFoundException(request.WarrantyId);

        var warrantyFeatureToRemove = warrantyToUpdate.WarrantyFeatures
            .ToList()
            .Where(warrantyFeature => request.WarrantyFeatures != null &&
                                      !request.WarrantyFeatures.Contains(warrantyFeature.FeatureId))
            .ToList();

        warrantyToUpdate.RemoveWarrantyFeatures(warrantyFeatureToRemove);

        var warrantyFeatureToAdd = new List<WarrantyFeature>();
        var listRequestWarrantyFeatures = request.WarrantyFeatures.ToList();

        foreach (var featureId in listRequestWarrantyFeatures)
        {
            var elementToUpdate = warrantyToUpdate.WarrantyFeatures.FirstOrDefault(x => x.FeatureId == featureId);
            if (elementToUpdate == null)
            {
                var pw = new WarrantyFeature
                {
                    WarrantyId = request.WarrantyId,
                    FeatureId = featureId
                };
                warrantyFeatureToAdd.Add(pw);
            }
            else
            {
                elementToUpdate.IsDeleted = false;
            }
        }

        warrantyToUpdate.AddWarrantyFeatures(warrantyFeatureToAdd);
        warrantyToUpdate.ReorderWarrantyFeatures();
        await _warrantyRepository.UpdateAsync(warrantyToUpdate, cancellationToken);

        return Unit.Value;
    }
}