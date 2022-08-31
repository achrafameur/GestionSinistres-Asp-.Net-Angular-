using InsuriseDTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Queries.GetCommissionDetail
{
    public class GetCommissionDetailQuery : IRequest<CommissionDto>
    {
        public GetCommissionDetailQuery(int commissionId)
        {
            CommissionId = commissionId;
        }

        public int CommissionId { get; set; }
    }
}
