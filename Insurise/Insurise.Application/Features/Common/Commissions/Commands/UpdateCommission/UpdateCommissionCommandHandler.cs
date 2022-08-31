using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Application.Features.Common.Natures.Commands.UpdateNature;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Commissions.Commands.UpdateCommission;

public class UpdateCommissionCommandHandler : IRequestHandler<UpdateCommissionCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Commission> _commissionRepository;

    public UpdateCommissionCommandHandler(IMapper mapper, IRepository<Commission> commissionRepository)
    {
        _mapper = mapper;
        _commissionRepository = commissionRepository;
    }

    public async Task<Unit> Handle(UpdateCommissionCommand request, CancellationToken cancellationToken)
    {
        var commissionToUpdate = await _commissionRepository.GetByIdAsync(request.CommissionId, cancellationToken);
        if (commissionToUpdate == null) throw new CommissionNotFoundException(request.CommissionId);
        _mapper.Map(request, commissionToUpdate, typeof(UpdateNatureCommand), typeof(Commission));
        await _commissionRepository.UpdateAsync(commissionToUpdate, cancellationToken);
        return Unit.Value;
    }
}