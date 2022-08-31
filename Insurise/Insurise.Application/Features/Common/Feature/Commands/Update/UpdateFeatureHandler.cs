using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.Update;

public class UpdateFeatureHandler : IRequestHandler<UpdateFeatureCommand>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;
    private readonly IMapper _mapper;

    public UpdateFeatureHandler(IRepository<Core.Entities.Common.Feature> featureRepository, IMapper mapper)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
    {
        var featureToUpdate =
            await _featureRepository.GetByIdAsync(request.FeatureId, cancellationToken);

        if (featureToUpdate == null) throw new FeatureNotFoundException(request.FeatureId);

        _mapper.Map(request, featureToUpdate, typeof(UpdateFeatureCommand), typeof(Core.Entities.Common.Feature));

        await _featureRepository.UpdateAsync(featureToUpdate, cancellationToken);

        return Unit.Value;
    }
}