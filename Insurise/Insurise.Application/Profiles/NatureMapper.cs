using AutoMapper;
using Insurise.Application.Features.Common.Natures.Commands.CreateNature;
using Insurise.Application.Features.Common.Natures.Commands.UpdateNature;
using Insurise.Application.Features.Common.Natures.Queries.GetNatureDetail;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class NatureMapper : Profile
{
    public NatureMapper()
    {
        CreateMap<CreateNatureCommand, Nature>();
        CreateMap<UpdateNatureCommand, Nature>();

        CreateMap<Nature, NatureDto>()
            .ConstructUsing(src => new NatureDto(src.Id, src.Title, src.IsList));
    }
}