using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Commands.UpdateCommission
{
    public class UpdateCommissionCommand : IRequest
    {
        public UpdateCommissionCommand(int commissionId, decimal value)
        {
            CommissionId = commissionId;
            this.value = value;
        }

        public int CommissionId { get; set; }
        public decimal value { get; set; }
    }
}
