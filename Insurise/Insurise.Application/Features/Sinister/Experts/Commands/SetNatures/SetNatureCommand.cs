using InsuriseDTO;
using InsuriseDTO.Sinister;
using MediatR;

namespace Insurise.Application.Features.Sinister.Experts.Commands.SetNatures;

public class SetNatureCommand : IRequest
{
    public ICollection<ExpertNatureDto>? ExpertNatures { get; set; }
}