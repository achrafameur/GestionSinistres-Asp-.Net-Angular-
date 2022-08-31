using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetSinisterNaturesFeatures;

public class SetSinisterNaturesFeaturesCommandHandler : IRequestHandler<SetSinisterNaturesFeaturesCommand>
{
    private readonly IRepository<SinisterNature> _SinisterNatureRepository;
    private readonly IMapper _mapper;

    public SetSinisterNaturesFeaturesCommandHandler(IMapper mapper,
        IRepository<SinisterNature> SinisterNatureRepository)
    {
        _mapper = mapper;
        _SinisterNatureRepository = SinisterNatureRepository;
    }

    public async Task<Unit> Handle(SetSinisterNaturesFeaturesCommand request, CancellationToken cancellationToken)
    {
        if (request.SinisterNatureFeatures != null && request.SinisterNatureFeatures.Count > 0)
        {
            var FeaturestoAdd = new List<SinisterNatureFeature>();
            var SinistreNatureToUpdate =
                await _SinisterNatureRepository.GetByIdAsync(request.SinisterNatureId, cancellationToken);
            foreach (var pw in request.SinisterNatureFeatures)
            {
                var sinisterNatureFeature = _mapper.Map<SinisterNatureFeature>(pw);
                FeaturestoAdd.Add(sinisterNatureFeature);
            }

            SinistreNatureToUpdate.AddSinisterNatureFeatures(FeaturestoAdd);
            await _SinisterNatureRepository.UpdateAsync(SinistreNatureToUpdate, cancellationToken);
        }

        return Unit.Value;
    }
}