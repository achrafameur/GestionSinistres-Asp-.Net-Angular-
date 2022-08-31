using InsuriseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.Experts.Commands.SetSpecialities;

public class SetSpecialitiesCommand : IRequest
{
    public int ExpertId { get; set; }
    public ICollection<ExpertSpecialityDto>? ExpertSpecialities { get; set; }
}