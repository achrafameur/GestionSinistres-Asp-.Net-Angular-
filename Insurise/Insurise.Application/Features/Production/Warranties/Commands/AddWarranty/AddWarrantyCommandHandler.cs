using AutoMapper;
using Insurise.Core.Entities.Production.WarrantyAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Warranties.Commands.AddWarranty;

public class AddWarrantyCommandHandler : IRequestHandler<AddWarrantyCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IRepository<Warranty> _warrantyRepository;

    public AddWarrantyCommandHandler(IMapper mapper, IRepository<Warranty> warrantyRepository)
    {
        _mapper = mapper;
        _warrantyRepository = warrantyRepository;
    }

    public async Task<int> Handle(AddWarrantyCommand request, CancellationToken cancellationToken)
    {
        var warranty = _mapper.Map<Warranty>(request);
        warranty = await _warrantyRepository.AddAsync(warranty, cancellationToken);
        return warranty.Id;
    }
}