using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.DeleteWarrantyFeature
{
    public class DeleteWarrantyFeatureCommand : IRequest
    {
        public DeleteWarrantyFeatureCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
