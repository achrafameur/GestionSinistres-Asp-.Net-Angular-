using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyTax
{
    public class UpdateWarrantyTaxCommand : IRequest
    {
        public UpdateWarrantyTaxCommand(int id, string? description, int rank)
        {
            Id = id;
            Description = description;
            Rank = rank;
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public int Rank { get; set; }
    }
}
