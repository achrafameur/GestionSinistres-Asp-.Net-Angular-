using AutoMapper;
using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using Insurise.Application.Features.Common.Chains.Commands.CreateChain;
using Insurise.Application.Features.Common.Chains.Commands.UpdateChain;
using Insurise.Application.Features.Common.Chains.Queries.GetChainList;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class ChainMapper : Profile
{
    public ChainMapper()
    {
        //CreateMap<CreateChainCommand, Chain>().ConstructUsing(s => new Chain(s.Title))
        //     .ForMember(dto => dto.Title, opt => opt.MapFrom(s => s.Title));
        CreateMap<CreateChainCommand, Chain>().ForMember(x => x.Elements, opt => opt.Ignore());
        CreateMap<UpdateChainCommand, Chain>().ForMember(x => x.Elements, opt => opt.Ignore());
        CreateMap<ChainElementDto, ChainElement>();

        CreateMap<Chain, ChainDto>()
            .ConstructUsing(s => new ChainDto(s.Id, s.Title,
                s.Elements.Select(d => new ChainElementDto(d.Title, d.ChainId, d.Id)
                ).ToList()
            ));
    }
}