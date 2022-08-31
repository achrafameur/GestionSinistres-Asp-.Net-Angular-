// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using AutoMapper;
using Insurise.Application.Features.Production.Product.Commands.AddProduct;
using Insurise.Application.Features.Production.Product.Commands.UpdateProduct;
using Insurise.Application.Features.Production.Product.Commands.UpdateProductFee;
using Insurise.Application.Features.Production.Product.Commands.UpdateProductWarranty;
using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using InsuriseDTO.Common;
using InsuriseDTO.Production.Base;
using InsuriseDTO.Production.Products;

namespace Insurise.Application.Profiles;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<BaseFilterDto, BaseFilter>().IncludeAllDerived().ReverseMap();
        CreateMap<ProductFilterDto, ProductFilter>().ReverseMap();
        CreateMap<AddProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
        CreateMap<UpdateProductWarrantyCommand, ProductWarranty>();
        CreateMap<UpdateProductWarrantyCommand, ProductWarranty>();
        CreateMap<UpdateProductFeeCommand, ProductFee>();

        CreateMap<Product, ProductDto>()
        .ConstructUsing(s => new ProductDto(s.Id, s.Title, s.Description, s.StartDate, s.ExpirationDate, s.DefaultDiscount, s.BranchId,
        s.Code, s.Branch != null ? s.Branch.Title : "", s.CreatedDate, s.CreatedBy, s.Image, s.FileName))
            .ForMember(dto => dto.Branch, opt => opt.MapFrom(s => s.Branch != null ? s.Branch.Title : ""));

        CreateMap<ProductShopDto, ProductShop>()
         .ConstructUsing(src => new ProductShop(src.ProductId, src.ShopId, src.Reduction, src.DefaultProduct))
             .ForMember(c => c.Shop, option => option.Ignore())
                 .ForMember(c => c.Product, option => option.Ignore())
         ;

        CreateMap<ProductShop, ProductShopDto>()
                  .ConstructUsing(s => new ProductShopDto(s.Id, s.ProductId,
                   s.Product != null ? s.Product.Title : "",
                  s.ShopId,
                   s.Shop != null ? s.Shop.Title : "",
                    s.Shop != null ? s.Shop.Code : "-",
                  s.Reduction, s.DefaultProduct))
                     .ForMember(dto => dto.Shop, opt => opt.MapFrom(s => s.Shop != null ? s.Shop.Title : ""))
                        .ForMember(dto => dto.Product, opt => opt.MapFrom(s => s.Product != null ? s.Product.Title : "")) 
                         .ForMember(opt => opt.IsChecked, conf => conf.Ignore()) 
                            ;

        CreateMap<ProductWarrantyDto, ProductWarranty>();
        CreateMap<ProductWarranty, ProductWarrantyDto>()
             .ConstructUsing(s => new ProductWarrantyDto(s.Id, s.Mandatory, s.Rank, s.ProductId,
             s.WarrantyId, s.Warranty != null ? s.Warranty.Title : "", s.Product != null ? s.Product.Title : ""))
                .ForMember(dto => dto.Warranty, opt => opt.MapFrom(s => s.Warranty != null ? s.Warranty.Title : ""))
                   .ForMember(dto => dto.Product, opt => opt.MapFrom(s => s.Product != null ? s.Product.Title : ""));

        CreateMap<ProductFee, ProductFeeDto>()
            .ConstructUsing(s => new ProductFeeDto(s.Id, s.Rank, s.ProductId,
            s.FeeId, s.Fee != null ? s.Fee.Title : "", s.Product != null ? s.Product.Title : ""))
               .ForMember(dto => dto.Fees, opt => opt.MapFrom(s => s.Fee != null ? s.Fee.Title : ""))
                  .ForMember(dto => dto.Product, opt => opt.MapFrom(s => s.Product != null ? s.Product.Title : ""));





        CreateMap<ProductDuration, ProductDurationsDto>()
           .ConstructUsing(s => new ProductDurationsDto(s.Id, s.Product != null ? s.Product.Title : "", s.ProductId, s.Duration != null ? s.Duration.Title : ""
           , s.DurationId, s.actif,
              s.Proportions.Select(d => new ProductDurationProportionDto(
                  d.Id, d.title, d.Proportion.Title, d.ProportionId, d.ProductDuration.Duration.Title, d.ProductDurationId 
                  )
              ).ToList()
              ))
              .ForMember(dto => dto.Duration, opt => opt.MapFrom(s => s.Duration != null ? s.Duration.Title : ""))
                 .ForMember(dto => dto.Product, opt => opt.MapFrom(s => s.Product != null ? s.Product.Title : ""))
                 .ForMember(dto => dto.Proportions, opt => opt.MapFrom(s => s.Proportions != null ?
                  s.Proportions.Select(d => new ProductDurationProportionDto(
                      d.Id, d.title, d.Proportion.Title, d.ProportionId, d.ProductDuration.Duration.Title, d.ProductDurationId
                  )).ToList() : new List<ProductDurationProportionDto>()))
                 ;


        CreateMap<ProductDurationsDto, ProductDuration>()
         .ConstructUsing(src => new ProductDuration(src.ProductId, src.DurationId, src.Actif ))
             .ForMember(c => c.Product, option => option.Ignore()) 
                 .ForMember(c => c.Duration, option => option.Ignore())  ; 
        CreateMap<ProductDurationProportionDto, ProductDurationProportion>()
            .ConstructUsing(src => new ProductDurationProportion(src.ProportionId, src.ProductDurationId, src.Title))
                .ForMember(c => c.Proportion, option => option.Ignore())
                    .ForMember(c => c.ProductDuration, option => option.Ignore())
            ;

    }
}
