using AutoMapper;
using Insurise.Application.Features.Production.Warranties.Commands.AddWarranty;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarranty;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyCommission;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyFeature;
using Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyTax;
using Insurise.Application.Features.Production.Warranties.Queries.GetWarrantiesList;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters;
using InsuriseDTO;
using InsuriseDTO.Production.Base;
using InsuriseDTO.Production.Warranties;

namespace Insurise.Application.Profiles;

public class WarrantyMapper : Profile
{
    public WarrantyMapper()
    {
       
       
        CreateMap<AddWarrantyCommand, Warranty>();
        CreateMap<UpdateWarrantyCommand, Warranty>();
        CreateMap<UpdateWarrantyFeatureCommand, WarrantyFeature>();
        CreateMap<UpdateWarrantyTaxCommand, WarrantyTax>();
        CreateMap<UpdateWarrantyCommissionCommand, WarrantyCommission>();
        CreateMap<WarrantyFeatureDto, WarrantyFeature>(); 
        CreateMap<WarrantyFeature, WarrantyFeatureDto>()
            .ConstructUsing(s => new WarrantyFeatureDto(s.Id,s.Mandatory,s.Rank,s.FeatureId
            , s.WarrantyId, s.Feature != null ? s.Feature.Title : "", s.Warranty != null ? s.Warranty.Title : ""))
            .ForMember(dto => dto.Warranty, opt => opt.MapFrom(s => s.Warranty != null ? s.Warranty.Title : ""))
             .ForMember(dto => dto.Feature, opt => opt.MapFrom(s => s.Feature != null ? s.Feature.Title : ""));

        CreateMap<WarrantyTaxDto, WarrantyTax>();
        CreateMap<WarrantyTax, WarrantyTaxDto>()

            .ConstructUsing(x => new WarrantyTaxDto(x.Id, x.Rank, x.Description, x.TaxId, x.WarrantyId, x.Tax != null ? x.Tax.Title : "", x.Warranty != null ? x.Warranty.Title : ""))

            .ForMember(dto => dto.Warranty, opt => opt.MapFrom(s => s.Warranty != null ? s.Warranty.Title : ""))
             .ForMember(dto => dto.Tax, opt => opt.MapFrom(s => s.Tax != null ? s.Tax.Title : ""));

        CreateMap<WarrantyCommissionDto, WarrantyCommission>();
        CreateMap<WarrantyCommission, WarrantyCommissionDto>()

            .ConstructUsing(x => new WarrantyCommissionDto(x.Id,x.Rank, x.Description,x.CodeAgence,x.LibelleAgence, x.CommissionId, x.WarrantyId
            ,x.Commission!=null ?x.Commission.Value:0, x.Warranty != null ? x.Warranty.Title : ""))

            .ForMember(dto => dto.Warranty, opt => opt.MapFrom(s => s.Warranty != null ? s.Warranty.Title : ""))
             .ForMember(dto => dto.Commission, opt => opt.MapFrom(s => s.Commission!=null? s.Commission.Value:0));


        CreateMap<Warranty, WarrantyDto>()
            .ConstructUsing(s => new WarrantyDto(s.Id, s.Title, s.Symbol, s.Description, s.StartDate,
                s.EndDate, s.DefaultPeriod, s.IsCommercialRate, s.TypeTarif));
    }
}