using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Commands.AddCommission
{
    public class AddCommissionCommand : IRequest<int>
    {
        public AddCommissionCommand(decimal value)
        {
            this.value = value;
        }

        public decimal value { get; set; }
        public override string ToString()
        {
            return $"Item name: {value}; Created on:{DateTime.Now}";
        }
    }
}
