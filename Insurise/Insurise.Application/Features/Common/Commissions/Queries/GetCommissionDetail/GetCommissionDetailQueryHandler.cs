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

namespace Insurise.Application.Features.Common.Commissions.Queries.GetCommissionDetail
{
    public class GetCommissionDetailQueryHandler : IRequestHandler<GetCommissionDetailQuery, CommissionDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Commission> _commissionRepository;

        public GetCommissionDetailQueryHandler(IMapper mapper, IRepository<Commission> commissionRepository)
        {
            _mapper = mapper;
            _commissionRepository = commissionRepository;
        }

        public async Task<CommissionDto> Handle(GetCommissionDetailQuery request, CancellationToken cancellationToken)
        {
            var nature = await _commissionRepository.GetByIdAsync(request.CommissionId);
            var natureDetailDto = _mapper.Map<CommissionDto>(nature);
            return natureDetailDto;
        }
    }
}
