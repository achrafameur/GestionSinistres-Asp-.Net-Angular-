using AutoMapper;
using Insurise.Application.Features.Common.ChainElements.Commands.CreateChainElement;
using Insurise.Application.Features.Common.ChainElements.Commands.UpdateChainElement;
using Insurise.Application.Features.Common.ChainElements.Queries.GetChainElementList;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class ChainElementMapper : Profile
{
    public ChainElementMapper()
    {
        CreateMap<CreateChainElementCommand, ChainElement>();
        CreateMap<UpdateChainElementCommand, ChainElement>();

        CreateMap<ChainElement, ChainElementDto>()
            .ConstructUsing(src => new ChainElementDto(src.Title, src.ChainId, src.Id));
    }
}