using AutoMapper;
using Insurise.Application.Features.Common.Commissions.Commands.AddCommission;
using Insurise.Application.Features.Common.Commissions.Commands.UpdateCommission;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using InsuriseDTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Profiles
{
    public class CommissionMapper : Profile
    
    {
        public CommissionMapper()
        {

            CreateMap<AddCommissionCommand, Commission>();
            CreateMap<UpdateCommissionCommand, Commission>();
            CreateMap<Commission, CommissionDto>()
                .ConstructUsing(src => new CommissionDto(src.Id, src.Value));
        }
    }
}
