using AutoMapper;
using Insurise.Application.Features.Sinister.AvgCosts.Commands.AddAvgCost;
using Insurise.Application.Features.Sinister.AvgCosts.Commands.UpdateAvgCost;
using Insurise.Application.Features.Sinister.AvgCosts.Queries.GetAvgCostDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;

namespace Insurise.Application.Profiles;

public class AvgCostMapper : Profile
{
    public AvgCostMapper()
    {
        CreateMap<CreateSinisterNatureAverageCostCommand, SinisterNatureAverageCost>();
        CreateMap<UpdateSinisterNatureAverageCostCommand, SinisterNatureAverageCost>();

        CreateMap<SinisterNatureAverageCost, AvgCostDto>()
            .ConstructUsing(s => new AvgCostDto(s.Id, s.SinisterNatureId,
                s.SinisterNature != null ? s.SinisterNature.Title : "", s.AverageCost, s.DateStart, s.DateEnd))
            .ForMember(dto => dto.SinisterNature,
                opt => opt.MapFrom(s => s.SinisterNature != null ? s.SinisterNature.Title : ""));
    }
}