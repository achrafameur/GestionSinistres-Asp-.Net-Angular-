using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Commands.DeleteCommission
{
    public class DeleteCommissionCommand : IRequest
    {
        public DeleteCommissionCommand(int commissionId)
        {
            CommissionId = commissionId;
        }

        public int CommissionId { get; set; }
    }
}
