using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Product.Commands.UpdateProductWarranty;

public class UpdateProductWarrantyCommandHandler : IRequestHandler<UpdateProductWarrantyCommand>
{
    private readonly IRepository<ProductWarranty> _productWarrantyRepository;
    private readonly IMapper _mapper;

    public UpdateProductWarrantyCommandHandler(IMapper mapper, IRepository<ProductWarranty> productWarrantyRepository)
    {
        _mapper = mapper;
        _productWarrantyRepository = productWarrantyRepository;
    }

    public async Task<Unit> Handle(UpdateProductWarrantyCommand request, CancellationToken cancellationToken)
    {
        var productWarrantyToUpdate = await _productWarrantyRepository.GetByIdAsync(request.Id, cancellationToken);

        if (productWarrantyToUpdate == null) throw new ProductWarrantyNotFoundException(request.Id);

        _mapper.Map(request, productWarrantyToUpdate, typeof(UpdateProductWarrantyCommand), typeof(ProductWarranty));

        await _productWarrantyRepository.UpdateAsync(productWarrantyToUpdate, cancellationToken);

        return Unit.Value;
    }
}