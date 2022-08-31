using AutoMapper;
using Insurise.Application.Features.Common.Feature.Commands.Add;
using Insurise.Application.Features.Common.Feature.Commands.Update;
using Insurise.Application.Features.Common.Feature.Queries.GetList;
using Insurise.Core.Entities.Common;
using InsuriseDTO.Production.Feature;

namespace Insurise.Application.Profiles;

public class FeatureMapper : Profile
{
    public FeatureMapper()
    {
        CreateMap<AddFeatureCommand, Feature>();
        CreateMap<UpdateFeatureCommand, Feature>();
        CreateMap<FeatureItemDto, FeatureItem>();
        CreateMap<FeatureItem, FeatureItemDto>()
            .ConstructUsing(s => new FeatureItemDto(s.Id, s.Rank, s.ItemId, s.FeatureId,
                s.Item != null ? s.Item.Title : "", s.Feature != null ? s.Feature.Title : ""))
            .ForMember(dto => dto.Feature, opt => opt.MapFrom(s => s.Feature != null ? s.Feature.Title : ""))
            .ForMember(dto => dto.Item, opt => opt.MapFrom(s => s.Item != null ? s.Item.Title : ""));


        CreateMap<Feature, FeatureDto>()
            .ConstructUsing(s =>
                new FeatureDto(s.Id, s.Title, s.Description, s.Symbol, s.Fixed, s.Minimum, s.Maximum, s.Alterable,
                    s.IsPrincipal, s.RankShow, s.ChainId, s.Chain != null ? s.Chain.Title : "", s.NatureId,
                    s.Nature != null ? s.Nature.Title : ""))
            .ForMember(dto => dto.Nature, opt => opt.MapFrom(s => s.Nature != null ? s.Nature.Title : ""))
            .ForMember(dto => dto.Chain, opt => opt.MapFrom(s => s.Chain != null ? s.Chain.Title : ""));
    }
}