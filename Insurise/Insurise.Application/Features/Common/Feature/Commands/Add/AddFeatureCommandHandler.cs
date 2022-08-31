using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Feature.Commands.Add;

public class AddFeatureCommandHandler : IRequestHandler<AddFeatureCommand, int>
{
    private readonly IRepository<Core.Entities.Common.Feature> _featureRepository;
    private readonly IMapper _mapper;

    public AddFeatureCommandHandler(IRepository<Core.Entities.Common.Feature> featureRepository, IMapper mapper)
    {
        _featureRepository = featureRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddFeatureCommand request, CancellationToken cancellationToken)
    {
        var feature = _mapper.Map<Core.Entities.Common.Feature>(request);
        feature = await _featureRepository.AddAsync(feature, cancellationToken);

        return feature.Id;
    }
}