using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyFeature
{
    public class UpdateWarrantyFeatureCommand : IRequest
    {
        public UpdateWarrantyFeatureCommand(int id, bool mandatory, int rank)
        {
            Id = id;
            Mandatory = mandatory;
            Rank = rank;
        }

        public int Id { get; set; }
        public bool Mandatory { get; set; }
        public int Rank { get; set; }
    }
}
