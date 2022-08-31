using AutoMapper;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using InsuriseDTO;
using Insurise.Application.Features.Sinister.Experts.Queries.GetExpertDetail;
using Insurise.Application.Features.Sinister.Experts.Commands.AddExpert;
using Insurise.Application.Features.Sinister.Experts.Commands.UpdateExpert;

namespace Insurise.Application.Profiles;

public class ExpertMapper : Profile
{
    public ExpertMapper()
    {
        CreateMap<CreateExpertCommand, Expert>();
        CreateMap<UpdateExpertCommand, Expert>();

        CreateMap<Expert, ExpertDto>()
            .ConstructUsing(s => new ExpertDto(s.Id, s.TypeExpert, s.Code, s.FName, s.LName, s.Cin, s.Email,
                s.BirthDate, s.SexId, s.Tel, s.Fixe, s.Fax, s.Governorate, s.Address,
                s.CancellationDate, s.RegistrationDate));

        CreateMap<ExpertSinisterNatureDto, SinisterNatureExpert>();
        CreateMap<SinisterNatureExpert, ExpertSinisterNatureDto>()
            .ConstructUsing(s => new ExpertSinisterNatureDto(s.SinisterNatureId));

        CreateMap<GetExpertSinisterNaturesDto, SinisterNatureExpert>();
        CreateMap<SinisterNatureExpert, GetExpertSinisterNaturesDto>()
            .ConstructUsing(s => new GetExpertSinisterNaturesDto(s.SinisterNatureId,
                s.SinisterNature != null ? s.SinisterNature.Title : "", s.ExpertId, s.Expert != null ? s.Expert.FName : ""))
            .ForMember(dto => dto.SinisterNature,
                opt => opt.MapFrom(s => s.SinisterNature != null ? s.SinisterNature.Title : ""))
            .ForMember(dto => dto.Expert,
                opt => opt.MapFrom(s => s.Expert != null ? s.Expert.FName : ""));

        CreateMap<ExpertSpecialityDto, ExpertSpeciality>();
        CreateMap<ExpertSpeciality, ExpertSpecialityDto>()
            .ConstructUsing(s => new ExpertSpecialityDto(s.Mandatory, s.ChainElementId));

        CreateMap<GetExpertSpecialityDto, ExpertSpeciality>();
        CreateMap<ExpertSpeciality, GetExpertSpecialityDto>()
            .ConstructUsing(s => new GetExpertSpecialityDto(s.ChainElementId,
                s.ChainElement != null ? s.ChainElement.Title : "", s.ExpertId, s.Expert != null ? s.Expert.FName : ""))
            .ForMember(dto => dto.ChainElement,
                opt => opt.MapFrom(s => s.ChainElement != null ? s.ChainElement.Title : ""))
            .ForMember(dto => dto.Expert, opt => opt.MapFrom(s => s.Expert != null ? s.Expert.FName : ""));
    }
}