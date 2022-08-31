using AutoMapper;
using Insurise.Application.Features.Common.Items.Commands.CreateItem;
using Insurise.Application.Features.Common.Items.Commands.UpdateItem;
using Insurise.Application.Features.Common.Items.Queries.GetItemDetail;
using Insurise.Core.Entities.Common;
using InsuriseDTO;
using InsuriseDTO.Common;

namespace Insurise.Application.Profiles;

public class ItemMapper : Profile
{
    public ItemMapper()
    {
        CreateMap<CreateItemCommand, Item>();
        CreateMap<UpdateItemCommand, Item>();
        /*  CreateMap<ItemFeatureDto, FeatureItem>();
          CreateMap<FeatureItem, ItemFeatureDto>()
              .ConstructUsing(s => new ItemFeatureDto(s.Id, s.FeatureId));*/

        CreateMap<Item, ItemDto>()
            .ConstructUsing(src => new ItemDto(src.Id, src.Title));
    }
}