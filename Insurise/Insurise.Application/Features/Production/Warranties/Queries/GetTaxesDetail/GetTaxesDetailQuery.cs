using InsuriseDTO;
using InsuriseDTO.Production.Warranties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetTaxesDetail;

public class GetTaxesDetailQuery : IRequest<List<WarrantyTaxDto>>
{
    public GetTaxesDetailQuery(int warrantyId)
    {
        WarrantyId = warrantyId;
    }

    public int WarrantyId { get; set; }
}