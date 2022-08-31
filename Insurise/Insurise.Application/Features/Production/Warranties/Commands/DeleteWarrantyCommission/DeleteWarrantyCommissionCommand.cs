using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyCommission
{
    public class DeleteWarrantyCommissionCommand : IRequest
    {
        public DeleteWarrantyCommissionCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
