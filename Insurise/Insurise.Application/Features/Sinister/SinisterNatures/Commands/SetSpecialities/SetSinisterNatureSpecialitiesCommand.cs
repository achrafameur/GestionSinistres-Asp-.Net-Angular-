using InsuriseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InsuriseDTO.Sinister;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetSpecialities;

public class SetSinisterNatureSpecialitiesCommand : IRequest
{
    public int SinisterNatureId { get; set; }
    public ICollection<SinisterNatureSpecialityDto>? SinisterNatureSpecialities { get; set; }
}