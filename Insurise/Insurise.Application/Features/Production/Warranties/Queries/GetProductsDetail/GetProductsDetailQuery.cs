using InsuriseDTO;
using InsuriseDTO.Production.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetProductsDetail
{
    public class GetProductsDetailQuery : IRequest<List<ProductWarrantyDto>>
    {
        public GetProductsDetailQuery(int warrantyId)
        {
            WarrantyId = warrantyId;
        }

        public int WarrantyId {get; set;}
    }
}
