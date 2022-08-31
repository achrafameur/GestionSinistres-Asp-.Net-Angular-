using InsuriseDTO;
using InsuriseDTO.Sinister;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.SetSinisterNatures;

public class SetSinisterNaturesCommand : IRequest
{
    public int? expertId { get; set; }
    public List<ExpertSinisterNatureDto>? ExpertSinisterNatures { get; set; }
}