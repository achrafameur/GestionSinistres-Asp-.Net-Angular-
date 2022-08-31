using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyFeature;

public class UpdateWarrantyFeatureCommandHandler : IRequestHandler<UpdateWarrantyFeatureCommand>
{
    private readonly IRepository<WarrantyFeature> _warrantyFeatureRepository;
    private readonly IMapper _mapper;

    public UpdateWarrantyFeatureCommandHandler(IRepository<WarrantyFeature> warrantyFeatureRepository, IMapper mapper)
    {
        _warrantyFeatureRepository = warrantyFeatureRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateWarrantyFeatureCommand request, CancellationToken cancellationToken)
    {
        var warrantyFeatureToUpdate = await _warrantyFeatureRepository.GetByIdAsync(request.Id, cancellationToken);

        if (warrantyFeatureToUpdate == null) throw new WarrantyFeatureNotFoundException(request.Id);

        _mapper.Map(request, warrantyFeatureToUpdate, typeof(UpdateWarrantyFeatureCommand), typeof(WarrantyFeature));

        await _warrantyFeatureRepository.UpdateAsync(warrantyFeatureToUpdate, cancellationToken);

        return Unit.Value;
    }
}