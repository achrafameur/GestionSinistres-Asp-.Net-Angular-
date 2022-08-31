using InsuriseDTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Queries.GetCommissionsList
{
    public class GetCommissionsListQuery : IRequest<List<CommissionDto>>
    {
    }
}
