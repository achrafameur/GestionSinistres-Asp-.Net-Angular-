using AutoMapper;
using Insurise.Application.Features.Production.Proportions.Commands.AddProportion;
using Insurise.Application.Features.Production.Proportions.Commands.UpdateProportion;
using Insurise.Application.Features.Production.Proportions.Queries.GetProportionList;
using Insurise.Core.Entities.Common;

namespace Insurise.Application.Profiles;

public class ProportionMapper : Profile
{
    public ProportionMapper()
    {
        CreateMap<AddProportionCommand, Proportion>();
        CreateMap<UpdateProportionCommand, Proportion>();
        CreateMap<Proportion, ProportionDto>()
            .ConstructUsing(s => new ProportionDto(s.Id, s.Title, s.Occurence, s.AdditionalCosts));
    }
}