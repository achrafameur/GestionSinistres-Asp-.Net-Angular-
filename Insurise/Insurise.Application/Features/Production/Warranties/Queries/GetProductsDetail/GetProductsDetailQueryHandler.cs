using AutoMapper;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
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
    public class GetProductsDetailQueryHandler : IRequestHandler<GetProductsDetailQuery, List<ProductWarrantyDto>>
    {
        private readonly IRepository<Warranty> _warrantyRepository;
        
        private readonly IMapper _mapper;
        public GetProductsDetailQueryHandler(IRepository<Warranty> warrantyRepository, IMapper mapper)
        {
            _mapper = mapper;
            _warrantyRepository = warrantyRepository;

        }
        public async Task<List<ProductWarrantyDto>> Handle(GetProductsDetailQuery request, CancellationToken cancellationToken)
        {
            var filter = new WarrantyFilter
            {
                WarrantyId = request.WarrantyId,
                LoadChildren = true,
                Children = new List<string> { "ProductWarranties", "ProductWarranties.Product" },
                IsPagingEnabled = false
            };
            var productsByWarrantyIdSpec = new WarrantySpecSingleResult(filter);
            var productsByWarranty = await _warrantyRepository.GetBySpecAsync(productsByWarrantyIdSpec);
            var mappedWarranty = _mapper.Map<List<ProductWarrantyDto>>(productsByWarranty?.ProductWarranties.OrderBy(x => x.Rank));
            return mappedWarranty;
        }
    }
}
