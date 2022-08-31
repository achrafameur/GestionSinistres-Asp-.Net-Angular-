using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using PackageEntity = Insurise.Core.Entities.Production.ProductAggregate;

namespace Insurise.Application.Features.Production.Product.Commands.AddPackage;

public class AddPackageCommandHandler : IRequestHandler<AddPackageCommand, int>
{
    private readonly IRepository<PackageEntity.Product> _repository;
    private readonly IMapper _mapper;

    public AddPackageCommandHandler(IMapper mapper, IRepository<PackageEntity.Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<int> Handle(AddPackageCommand request, CancellationToken cancellationToken)
    {
        var package = _mapper.Map<PackageEntity.Product>(request);
        var productChild = new List<PackageEntity.Product>();
        if (request.selectedProducts != null)
        {
            foreach (var s in request.selectedProducts)
            {
                var productToAdd = await _repository.GetByIdAsync(s, cancellationToken);

                if (productToAdd == null) throw new PackageNotFoundException(s);
                productChild.Add(productToAdd);
            }

            package.AddProductChild(productChild);
        }

        package = await _repository.AddAsync(package, cancellationToken);

        return package.Id;
    }
}