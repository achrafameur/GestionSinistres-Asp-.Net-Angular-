using InsuriseDTO;
using InsuriseDTO.Production.Warranties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.SetTaxes;

public class SetTaxesCommand : IRequest
{
    public int WarrantyId { get; set; }
    public ICollection<int>? WarrantyTaxes { get; set; }
}