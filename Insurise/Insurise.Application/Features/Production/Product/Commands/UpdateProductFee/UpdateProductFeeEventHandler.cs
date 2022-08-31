using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;


namespace Insurise.Application.Features.Production.Product.Commands.UpdateProductFee;

public class UpdateProductFeeCommandEventHandler : IRequestHandler<UpdateProductFeeCommand>
{
    private readonly IRepository<ProductEntity.ProductFee> _productFeeRepository;
    private readonly IMapper _mapper;

    public UpdateProductFeeCommandEventHandler(IMapper mapper, IRepository<ProductEntity.ProductFee> productFeeRepository)
    {
        _mapper = mapper;
        _productFeeRepository = productFeeRepository;
    }

    public async Task<Unit> Handle(UpdateProductFeeCommand request, CancellationToken cancellationToken)
    {
        var productFeeToUpdate = await _productFeeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (productFeeToUpdate == null) throw new ProductFeeNotFoundException(request.Id);

        _mapper.Map(request, productFeeToUpdate, typeof(UpdateProductFeeCommand), typeof(ProductEntity.ProductFee));

        await _productFeeRepository.UpdateAsync(productFeeToUpdate, cancellationToken);

        return Unit.Value;
    }
}
