using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.Core.Entities.Production.ProductAggregate;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Common;
using InsuriseDTO.Production.Products;
using MediatR;
using System.Linq;
using Insurise.Core.Specifications.Filters.Commun.Shops;
using Insurise.Core.Specifications.Filters.Product;

namespace Insurise.Application.Features.Production.Product.Queries.GetProductShopsList;

public class GetProductShopsListQueryHandler : IRequestHandler<GetProductShopsListQuery, List<ProductShopDto>>
{
    private readonly IRepository<Shop> _ShopsRepository;
    private readonly IMapper _mapper;

    public GetProductShopsListQueryHandler(IMapper mapper, IRepository<Shop> shopsRepository)
    {
        _mapper = mapper;
        _ShopsRepository = shopsRepository;
    }

    public async Task<List<ProductShopDto>?> Handle(GetProductShopsListQuery request,
        CancellationToken cancellationToken)
    {
        if (request.ProductId.HasValue)
        {
            var filter = new ProductFilter();
            filter.LoadChildren = true;
            filter.ProductId = request.ProductId.Value;
            filter.Children = new List<string> {"ProductShops", "ProductShops.Product"};
            var spec = new ShopSpec(filter);
            var Shops = await _ShopsRepository.ListAsync(spec, cancellationToken);

            var allShops = Shops.Select(item =>
                new ProductShopDto
                {
                    IsChecked = item.ProductShops.Any(x => x.ProductId == request.ProductId && !x.IsDeleted),
                    Id = item.ProductShops.Any(x => x.ProductId == request.ProductId && !x.IsDeleted)
                        ? item.ProductShops.FirstOrDefault(x => x.ProductId == request.ProductId && !x.IsDeleted).Id
                        : 0,
                    ProductId = item.ProductShops.Any(x => x.ProductId == request.ProductId && !x.IsDeleted)
                        ? item.ProductShops.FirstOrDefault(x => x.ProductId == request.ProductId && !x.IsDeleted)
                            .ProductId
                        : 0,
                    Product = item.ProductShops.Any(x => x.ProductId == request.ProductId && !x.IsDeleted)
                        ? item.ProductShops.FirstOrDefault(x => x.ProductId == request.ProductId && !x.IsDeleted)
                            .Product.Title.ToString()
                        : "",
                    ShopId = item.Id,
                    Shop = item.Title,
                    ShopCode = item.Code,
                    Reduction = item.ProductShops.Any(x => x.ProductId == request.ProductId && !x.IsDeleted)
                        ? item.ProductShops.FirstOrDefault(x => x.ProductId == request.ProductId && !x.IsDeleted)
                            .Reduction
                        : 0,
                    DefaultProduct = item.ProductShops.Any(x => x.ProductId == request.ProductId && !x.IsDeleted)
                        ? item.ProductShops.FirstOrDefault(x => x.ProductId == request.ProductId && !x.IsDeleted)
                            .DefaultProduct
                        : 0
                }).ToList();

            return allShops;
        }

        return null;
    }
}