using AutoMapper;
using Insurise.Application.Features.Sinister.SinisterBinders.Commands.AddSinisterBinder;
using Insurise.Application.Features.Sinister.SinisterBinders.Commands.UpdateSinisterBinder;
using Insurise.Application.Features.Sinister.SinisterBinders.Queries.GetSinisterBinderDetail;
using Insurise.Core.Entities.Sinister.SinisterAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Profiles;

public class SinisterBinderMapper : Profile
{
    public SinisterBinderMapper()
    {
        CreateMap<AddSinisterBinderCommand, SinisterBinder>();
        CreateMap<UpdateSinisterBinderCommand, SinisterBinder>();

        CreateMap<SinisterBinder, SinisterBinderDto>()
            .ConstructUsing(s => new SinisterBinderDto(s.Id, s.SinisterDate, s.SinisterTime, s.SinisterPlace,
                s.PolicyNumber,
                s.InsuredName, s.InsuredObject, s.Description, s.ReclamationDate, s.CreatedDate));
    }
}