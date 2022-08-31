using AutoMapper;
using Insurise.Application.Features.Sinister.Tiers.Commands.AddTiers;
using Insurise.Application.Features.Sinister.Tiers.Commands.UpdateTiers;
using Insurise.Application.Features.Sinister.Tiers.Queries.GetTiersDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;

namespace Insurise.Application.Profiles;

public class TiersMapper : Profile
{
    public TiersMapper()
    {
        CreateMap<CreateTiersCommand, Tiers>();
        CreateMap<UpdateTiersCommand, Tiers>();

        CreateMap<Tiers, TiersDto>()
            .ConstructUsing(s => new TiersDto(s.Id, s.Title, s.Label, s.Description, s.TaxRegistrationNumber, s.Phone,
                s.Fax, s.Email, s.TiersCompanyId, s.TiersCompany != null ? s.TiersCompany.Label : ""))
            .ForMember(dto => dto.TiersCompany,
                opt => opt.MapFrom(s => s.TiersCompany != null ? s.TiersCompany.Label : ""));
    }
}