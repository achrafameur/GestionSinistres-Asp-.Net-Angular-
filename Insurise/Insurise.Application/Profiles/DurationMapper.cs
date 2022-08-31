using AutoMapper;
using Insurise.Application.Features.Production.Durations.Commands.AddDuration;
using Insurise.Application.Features.Production.Durations.Commands.UpdateDuration;
using Insurise.Application.Features.Production.Durations.Queries.GetDurationDetail;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class DurationMapper : Profile
{
    public DurationMapper()
    {
        CreateMap<CreateDurationCommand, Duration>();
        CreateMap<UpdateDurationCommand, Duration>();

        CreateMap<Duration, DurationDetailDto>()
            .ConstructUsing(s =>
                new DurationDetailDto(s.Id, s.Title, s.Type, s.Value, s.Coefficient, s.StartDate, s.EndDate,
                    s.Renewable));
    }
}