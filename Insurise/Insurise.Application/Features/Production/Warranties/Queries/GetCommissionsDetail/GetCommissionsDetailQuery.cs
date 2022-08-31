using InsuriseDTO.Production.Warranties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetCommissionsDetail;

public class GetCommissionsDetailQuery : IRequest<List<WarrantyCommissionDto>>
{
    public GetCommissionsDetailQuery(int warrantyId)
    {
        WarrantyId = warrantyId;
    }

    public int WarrantyId { get; private set; }
}