using AutoMapper;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using ProductEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Commands.AddProduct;

public class AddProductCommandHandler : IRequestHandler<AddProductCommand, int>
{
    private readonly IRepository<ProductEntity.Product> _ProductRepository;
    private readonly IMapper _mapper;

    public AddProductCommandHandler(IMapper mapper, IRepository<ProductEntity.Product> ProductRepository)
    {
        _mapper = mapper;
        _ProductRepository = ProductRepository;
    }

    public async Task<int> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var Product = _mapper.Map<ProductEntity.Product>(request);
        Product = await _ProductRepository.AddAsync(Product, cancellationToken);

        return Product.Id;
    }
}