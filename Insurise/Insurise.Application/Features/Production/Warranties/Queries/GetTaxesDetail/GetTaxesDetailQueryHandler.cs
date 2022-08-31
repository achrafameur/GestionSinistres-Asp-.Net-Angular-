using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.Core.Specifications.Filters.Warranties;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO;
using InsuriseDTO.Production.Warranties;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Queries.GetTaxesDetail;

public class GetTaxesDetailQueryHandler : IRequestHandler<GetTaxesDetailQuery, List<WarrantyTaxDto>>
{
    private readonly IRepository<Warranty> _warrantyRepository;
    private readonly IMapper _mapper;

    public GetTaxesDetailQueryHandler(IRepository<Warranty> warrantyRepository, IMapper mapper)
    {
        _warrantyRepository = warrantyRepository;
        _mapper = mapper;
    }

    public async Task<List<WarrantyTaxDto>> Handle(GetTaxesDetailQuery request, CancellationToken cancellationToken)
    {
        var filter = new WarrantyFilter
        {
            WarrantyId = request.WarrantyId,
            LoadChildren = true,
            Children = new List<string> {"WarrantyTaxesNotDeleted", "WarrantyTaxes.Tax"},
            IsPagingEnabled = false
        };
        var taxesByWarrantyIdSpec = new WarrantySpecSingleResult(filter);


        var taxesByWarranty = await _warrantyRepository.GetBySpecAsync(taxesByWarrantyIdSpec);
        var mappedWarranty = _mapper.Map<List<WarrantyTaxDto>>(taxesByWarranty?.WarrantyTaxes.OrderBy(x => x.TaxId));
        return mappedWarranty;
    }
}