using InsuriseDTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Sinister.SinisterNatures.Commands.SetMandatoryDocuments;

public class SetMandatoryDocumentsCommand : IRequest
{
    public int SinisterNatureId { get; set; }
    public ICollection<SinisterNatureMandatoryDocumentDto>? SinisterNatureMandatoryDocuments { get; set; }
}