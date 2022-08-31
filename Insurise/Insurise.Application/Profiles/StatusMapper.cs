using AutoMapper;
using Insurise.Application.Features.Common.Status.Commands.AddStatus;
using Insurise.Application.Features.Common.Status.Commands.UpdateStatus;
using Insurise.Application.Features.Common.Status.Queries.GetStatusDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;

namespace Insurise.Application.Profiles;

public class StatusMapper : Profile
{
    public StatusMapper()
    {
        CreateMap<CreateStatusCommand, Status>();
        CreateMap<UpdateStatusCommand, Status>();

        CreateMap<Status, StatusDto>()
            .ConstructUsing(s => new StatusDto(s.Id, s.Title, s.Symbol, s.ItemId, s.Item != null ? s.Item.Title : ""))
            .ForMember(dto => dto.Item, opt => opt.MapFrom(s => s.Item != null ? s.Item.Title : ""));
    }
}