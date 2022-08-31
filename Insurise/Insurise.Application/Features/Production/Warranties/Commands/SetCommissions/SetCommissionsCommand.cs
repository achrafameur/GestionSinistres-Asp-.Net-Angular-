using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.SetCommissions;

public class SetCommissionsCommand : IRequest
{
    public int WarrantyId { get; set; }
    public ICollection<int>? WarrantyCommissions { get; set; }
}