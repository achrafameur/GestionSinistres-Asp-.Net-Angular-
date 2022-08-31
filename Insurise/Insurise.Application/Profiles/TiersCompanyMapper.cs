using AutoMapper;
using Insurise.Application.Features.Sinister.TiersCompanies.Commands.AddTiersCompany;
using Insurise.Application.Features.Sinister.TiersCompanies.Commands.UpdateTiersCompany;
using Insurise.Application.Features.Sinister.TiersCompanies.Queries.GetTiersCompanyDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;

namespace Insurise.Application.Profiles;

public class TiersCompanyMapper : Profile
{
    public TiersCompanyMapper()
    {
        CreateMap<CreateTiersCompanyCommand, TiersCompany>();
        CreateMap<UpdateTiersCompanyCommand, TiersCompany>();

        CreateMap<TiersCompany, TiersCompanyDto>()
            .ConstructUsing(s => new TiersCompanyDto(s.Id, s.TaxRegistrationNumber, s.Label, s.Description, s.Phone,
                s.Fax, s.Email, s.Address));
    }
}