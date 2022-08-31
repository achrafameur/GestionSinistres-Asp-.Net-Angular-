using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarranty;

public class UpdateWarrantyCommandHandler : IRequestHandler<UpdateWarrantyCommand>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Warranty> _warrantyRepository;

    public UpdateWarrantyCommandHandler(IMapper mapper, IRepository<Warranty> warrantyRepository)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<Unit> Handle(UpdateWarrantyCommand request, CancellationToken cancellationToken)
    {
        var warrantyToUpdate = await _warrantyRepository.GetByIdAsync(request.WarrantyId, cancellationToken);
        if (warrantyToUpdate == null) throw new WarrantyNotFoundException(request.WarrantyId);
        _mapper.Map(request, warrantyToUpdate, typeof(UpdateWarrantyCommand), typeof(Warranty));
        await _warrantyRepository.UpdateAsync(warrantyToUpdate, cancellationToken);
        return Unit.Value;
    }
}