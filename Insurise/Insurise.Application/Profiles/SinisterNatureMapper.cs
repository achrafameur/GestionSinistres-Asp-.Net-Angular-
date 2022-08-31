using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using InsuriseDTO;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureFeatures;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureMandatoryDocuments;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureSpecialities;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.AddSinisterNature;
using Insurise.Application.Features.Sinister.SinisterNatures.Commands.UpdateSinisterNature;
using Insurise.Application.Features.Sinister.SinisterNatures.Queries.GetSinisterNatureDetail;
using InsuriseDTO.Sinister;

namespace Insurise.Application.Profiles;

public class SinisterNatureMapper : Profile
{
    public SinisterNatureMapper()
    {
        CreateMap<CreateSinisterNatureCommand, SinisterNature>();
        CreateMap<UpdateSinisterNatureCommand, SinisterNature>();

        CreateMap<SinisterNature, SinisterNatureDto>()
            .ConstructUsing(s => new SinisterNatureDto(s.Id, s.Title, s.Code, s.BranchId,
                s.Branch != null ? s.Branch.Title : "", s.IdaEnabled, s.TransactionEnabled,
                s.ThirdPartyEnabled, s.VictimEnabled, s.FormulaEvaluationId, s.FormulaFeesId, s.RespEnabled,
                s.RespAutoEnabled, s.AffaireEnabled,
                s.ExpertiseEnabled, s.EvalInterneEnabled, s.EvalInterneCorpEnabled, s.RegExpertEnabled, s.IsChecked))
            .ForMember(dto => dto.Branch, opt => opt.MapFrom(s => s.Branch != null ? s.Branch.Title : ""));

        CreateMap<SinisterNatureFeatureDto, SinisterNatureFeature>();
        CreateMap<SinisterNatureFeature, SinisterNatureFeatureDto>()
            .ConstructUsing(s => new SinisterNatureFeatureDto(s.FeatureId));

        CreateMap<SinisterNatureSpecialityDto, SinisterNatureSpeciality>();
        CreateMap<SinisterNatureSpeciality, SinisterNatureSpecialityDto>()
            .ConstructUsing(s => new SinisterNatureSpecialityDto(s.ChainElementId));

        CreateMap<SinisterNatureMandatoryDocumentDto, SinisterNatureMandatoryDocument>();
        CreateMap<SinisterNatureMandatoryDocument, SinisterNatureMandatoryDocumentDto>()
            .ConstructUsing(s => new SinisterNatureMandatoryDocumentDto(s.MandatoryDocumentId));

        CreateMap<GetSinisterNatureFeaturesDto, SinisterNatureFeature>();
        CreateMap<SinisterNatureFeature, GetSinisterNatureFeaturesDto>()
            .ConstructUsing(s => new GetSinisterNatureFeaturesDto(s.FeatureId, s.Feature != null ? s.Feature.Title : "",
                s.SinisterNatureId, s.SinisterNature != null ? s.SinisterNature.Title : ""))
            .ForMember(dto => dto.Feature, opt => opt.MapFrom(s => s.Feature != null ? s.Feature.Title : ""))
            .ForMember(dto => dto.SinisterNature,
                opt => opt.MapFrom(s => s.SinisterNature != null ? s.SinisterNature.Title : ""));

        CreateMap<GetSinisterNatureMandatoryDocumentsDto, SinisterNatureMandatoryDocument>();
        CreateMap<SinisterNatureMandatoryDocument, GetSinisterNatureMandatoryDocumentsDto>()
            .ConstructUsing(s => new GetSinisterNatureMandatoryDocumentsDto(s.MandatoryDocumentId,
                s.MandatoryDocument != null ? s.MandatoryDocument.Title : "", s.SinisterNatureId,
                s.SinisterNature != null ? s.SinisterNature.Title : ""))
            .ForMember(dto => dto.MandatoryDocument,
                opt => opt.MapFrom(s => s.MandatoryDocument != null ? s.MandatoryDocument.Title : ""))
            .ForMember(dto => dto.SinisterNature,
                opt => opt.MapFrom(s => s.SinisterNature != null ? s.SinisterNature.Title : ""));

        CreateMap<GetSinisterNatureSpecialitiesDto, SinisterNatureSpeciality>();
        CreateMap<SinisterNatureSpeciality, GetSinisterNatureSpecialitiesDto>()
            .ConstructUsing(s => new GetSinisterNatureSpecialitiesDto(s.ChainElementId,
                s.ChainElement != null ? s.ChainElement.Title : "", s.SinisterNatureId,
                s.SinisterNature != null ? s.SinisterNature.Title : ""))
            .ForMember(dto => dto.ChainElement,
                opt => opt.MapFrom(s => s.ChainElement != null ? s.ChainElement.Title : ""))
            .ForMember(dto => dto.SinisterNature,
                opt => opt.MapFrom(s => s.SinisterNature != null ? s.SinisterNature.Title : ""));
    }
}