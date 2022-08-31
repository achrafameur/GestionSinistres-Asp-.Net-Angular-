using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurise.Application.Features.Production.Warranties.Commands.UpdateWarrantyTax;

public class UpdateWarrantyTaxCommandHandler : IRequestHandler<UpdateWarrantyTaxCommand>
{
    private readonly IRepository<WarrantyTax> _warrantyTaxRepository;
    private readonly IMapper _mapper;

    public UpdateWarrantyTaxCommandHandler(IRepository<WarrantyTax> warrantyTaxRepository, IMapper mapper)
    {
        _warrantyTaxRepository = warrantyTaxRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateWarrantyTaxCommand request, CancellationToken cancellationToken)
    {
        var warrantyTaxToUpdate = await _warrantyTaxRepository.GetByIdAsync(request.Id, cancellationToken);

        if (warrantyTaxToUpdate == null) throw new WarrantyTaxNotFoundException(request.Id);

        _mapper.Map(request, warrantyTaxToUpdate, typeof(UpdateWarrantyTaxCommand), typeof(WarrantyTax));

        await _warrantyTaxRepository.UpdateAsync(warrantyTaxToUpdate, cancellationToken);

        return Unit.Value;
    }
}