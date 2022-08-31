using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyTax
{
    public class DeleteWarrantyTaxCommand : IRequest
    {
        public DeleteWarrantyTaxCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
