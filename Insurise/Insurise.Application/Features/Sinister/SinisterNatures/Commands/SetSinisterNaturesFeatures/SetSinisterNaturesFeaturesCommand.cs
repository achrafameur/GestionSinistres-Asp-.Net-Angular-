using InsuriseDTO;
using MediatR;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetSinisterNaturesFeatures;

public class SetSinisterNaturesFeaturesCommand : IRequest
{
    public int SinisterNatureId { get; set; }
    public ICollection<SinisterNatureFeatureDto>? SinisterNatureFeatures { get; set; }
}