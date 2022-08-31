using AutoMapper;
using Insurise.Application.Features.Common.Shops.Commands.AddShops;
using Insurise.Application.Features.Common.Shops.Commands.UpdateShops;
using Insurise.Core.Entities.Common;
using InsuriseDTO.Common;

namespace Insurise.Application.Profiles;

public class ShopsMapper : Profile
{
    public ShopsMapper()
    {
        CreateMap<Shop, CreateShopsCommand>().ReverseMap();
        CreateMap<Shop, UpdateShopsCommand>().ReverseMap();
        CreateMap<Shop, ShopDto>()
            .ConstructUsing(s => new ShopDto(s.Id, s.Title, (int) Enum.Parse(s.Type.GetType(), s.Type.ToString()),
                s.Code, s.Description, s.DepartmentId
            ));
        //s.Elements.Select(d => new ChainElementDto(d.Title, d.ChainId, d.Id)).ToList()
    }
}