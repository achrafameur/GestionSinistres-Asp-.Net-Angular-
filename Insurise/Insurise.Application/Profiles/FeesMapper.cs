using AutoMapper;
using Insurise.Application.Features.Production.Fees.Commands.AddFees;
using Insurise.Application.Features.Production.Fees.Commands.UpdateFees;
using Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class FeesMapper : Profile
{
    public FeesMapper()
    {
        CreateMap<Fee, CreateFeesCommand>().ReverseMap();
        CreateMap<Fee, UpdateFeesCommand>().ReverseMap();
        CreateMap<Fee, FeesDto>()
            .ConstructUsing(s => new FeesDto(s.Id, s.Title, s.Symbol, s.Description, s.Type, s.Equation));
    }
}