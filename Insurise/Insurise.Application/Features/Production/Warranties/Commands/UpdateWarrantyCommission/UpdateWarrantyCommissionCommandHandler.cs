using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyCommission;

public class UpdateWarrantyCommissionCommandHandler : IRequestHandler<UpdateWarrantyCommissionCommand>
{
    private readonly IRepository<WarrantyCommission> _warrantyCommissionRepository;
    private readonly IMapper _mapper;

    public UpdateWarrantyCommissionCommandHandler(IRepository<WarrantyCommission> warrantyCommissionRepository,
        IMapper mapper)
    {
        _warrantyCommissionRepository = warrantyCommissionRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateWarrantyCommissionCommand request, CancellationToken cancellationToken)
    {
        var warrantyCommissionToUpdate = await _warrantyCommissionRepository.GetByIdAsync(request.Id, cancellationToken);

        if (warrantyCommissionToUpdate == null) throw new WarrantyCommissionNotFoundException(request.Id);

        _mapper.Map(request, warrantyCommissionToUpdate, typeof(UpdateWarrantyCommissionCommand),
            typeof(WarrantyCommission));

        await _warrantyCommissionRepository.UpdateAsync(warrantyCommissionToUpdate, cancellationToken);

        return Unit.Value;
    }
}