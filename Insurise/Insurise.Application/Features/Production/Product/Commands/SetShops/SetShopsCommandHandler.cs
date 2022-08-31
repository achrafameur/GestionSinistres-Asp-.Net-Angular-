using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using PackageEntity = Insurise.Core.Entities.Production.ProductAggregate;


namespace Insurise.Application.Features.Production.Product.Commands.SetShops;

public class SetShopsCommandHandler : IRequestHandler<SetShopsCommand>
{
    private readonly IRepository<PackageEntity.Product> _repository;
    private readonly IMapper _mapper;

    public SetShopsCommandHandler(IMapper mapper, IRepository<PackageEntity.Product> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Unit> Handle(SetShopsCommand request, CancellationToken cancellationToken)
    {
        var filter = new ProductFilter
        {
            ProductId = request.ProductId,
            LoadChildren = true,
            Children = new List<string> {"ProductShops"},
            IsPagingEnabled = false
        };
        var productSpec = new ProductSpecSingleResult(filter);
        var productToUpdate = await _repository.GetBySpecAsync(productSpec, cancellationToken);
        if (productToUpdate == null) throw new ProductNotFoundException(request.ProductId);

        var productShopsToRemove = productToUpdate.ProductShops.ToList()
            .Where(productShops => request.ProductShops != null &&
                                   request.ProductShops.FirstOrDefault(x => x.ShopId == productShops.ShopId) == null)
            .ToList();

        productToUpdate.RemoveProductShops(productShopsToRemove);
        var productShopToAdd = new List<PackageEntity.ProductShop>();
        var listRequestProductShops = request.ProductShops?.ToList();
        if (listRequestProductShops != null)
            foreach (var productShopDto in listRequestProductShops)
            {
                var elementToUpdate =
                    productToUpdate.ProductShops.FirstOrDefault(x => x.ShopId == productShopDto.ShopId);
                if (elementToUpdate == null)
                {
                    productShopDto.ProductId = request.ProductId;
                    var productShop = _mapper.Map<PackageEntity.ProductShop>(productShopDto);
                    //ProductShop pw = new ProductShop
                    //{
                    //    ProductId = request.ProductId,
                    //    ShopId = productShop.ShopId
                    //};
                    productShopToAdd.Add(productShop);
                }
                else
                {
                    //  _mapper.Map(productShopDto, elementToUpdate, typeof(ProductShopDto), typeof(ProductShop));
                    elementToUpdate.Reduction = productShopDto.Reduction;
                    elementToUpdate.DefaultProduct = productShopDto.DefaultProduct;
                    elementToUpdate.IsDeleted = false;
                }
            }

        productToUpdate.AddProductShops(productShopToAdd);
        await _repository.UpdateAsync(productToUpdate, cancellationToken);

        return Unit.Value;
    }
}