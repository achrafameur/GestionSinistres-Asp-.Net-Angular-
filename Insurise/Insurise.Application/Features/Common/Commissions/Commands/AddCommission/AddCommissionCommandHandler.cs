using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Common.Commissions.Commands.AddCommission
{
    public class AddCommissionCommandHandler : IRequestHandler<AddCommissionCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Commission> _commissionRepository;

        public AddCommissionCommandHandler(IMapper mapper, IRepository<Commission> commissionRepository)
        {
            _mapper = mapper;
            _commissionRepository = commissionRepository;
        }

        public async Task<int> Handle(AddCommissionCommand request, CancellationToken cancellationToken)
        {
            var commission = _mapper.Map<Commission>(request);
            commission = await _commissionRepository.AddAsync(commission, cancellationToken);
            return commission.Id;
        }
    }
}
