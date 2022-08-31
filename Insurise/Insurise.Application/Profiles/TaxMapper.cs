using AutoMapper;
using Insurise.Application.Features.Production.Tax.Commands.AddTax;
using Insurise.Application.Features.Production.Tax.Commands.UpdateTax;
using Insurise.Application.Features.Production.Tax.Queries.GetTaxList;
using Insurise.Core.Entities.Production.WarrantyAggregate;

namespace Insurise.Application.Profiles;

public class TaxMapper : Profile
{
    public TaxMapper()
    {
        CreateMap<CreateTaxCommand, Tax>();
        CreateMap<UpdateTaxCommand, Tax>();

        CreateMap<Tax, TaxDto>()
            .ConstructUsing(src => new TaxDto(src.Id, src.Title, src.Description, src.Coefficient, src.Constant));
    }
}