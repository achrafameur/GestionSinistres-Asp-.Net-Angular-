using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Queries.GetCommissionsList
{
    public class GetCommissionsListQueryHandler : IRequestHandler<GetCommissionsListQuery, List<CommissionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Commission> _commissionRepository;

        public GetCommissionsListQueryHandler(IMapper mapper, IRepository<Commission> commissionRepository)
        {
            _mapper = mapper;
            _commissionRepository = commissionRepository;
        }

        public async Task<List<CommissionDto>> Handle(GetCommissionsListQuery request, CancellationToken cancellationToken)
        {
            var commissions = (await _commissionRepository.ListAsync(cancellationToken)).OrderBy(x => x.Value);
            return _mapper.Map<List<CommissionDto>>(commissions);
        }
    }
}
