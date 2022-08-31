using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyFeature;

public class DeleteWarrantyFeatureCommandHandler : IRequestHandler<DeleteWarrantyFeatureCommand>
{
    private readonly IRepository<WarrantyFeature> _warrantyFeatureRepository;

    public DeleteWarrantyFeatureCommandHandler(IRepository<WarrantyFeature> warrantyFeatureRepository)
    {
        _warrantyFeatureRepository = warrantyFeatureRepository;
    }

    public async Task<Unit> Handle(DeleteWarrantyFeatureCommand request, CancellationToken cancellationToken)
    {
        var warrantyFeatureToDelete = await _warrantyFeatureRepository.GetByIdAsync(request.Id, cancellationToken);
        if (warrantyFeatureToDelete == null) throw new WarrantyFeatureNotFoundException(request.Id);
        warrantyFeatureToDelete.IsDeleted = true;
        await _warrantyFeatureRepository.UpdateAsync(warrantyFeatureToDelete, cancellationToken);

        return Unit.Value;
    }
}