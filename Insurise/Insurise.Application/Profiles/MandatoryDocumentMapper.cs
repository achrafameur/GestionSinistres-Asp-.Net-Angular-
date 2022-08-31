using AutoMapper;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.AddMandatoryDocument;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Commands.UpdateMandatoryDocument;
using Insurise.Application.Features.Sinister.MandatoryDocuments.Queries.GetMandatoryDocumentList;
using Insurise.Core.Entities.Sinister.SinisterAggregate;

namespace Insurise.Application.Profiles;

public class MandatoryDocumentMapper : Profile
{
    public MandatoryDocumentMapper()
    {
        CreateMap<CreateMandatoryDocumentCommand, MandatoryDocument>();
        CreateMap<UpdateMandatoryDocumentCommand, MandatoryDocument>();

        CreateMap<MandatoryDocument, MandatoryDocumentDto>()
            .ConstructUsing(s => new MandatoryDocumentDto(s.Id, s.Title));
    }
}