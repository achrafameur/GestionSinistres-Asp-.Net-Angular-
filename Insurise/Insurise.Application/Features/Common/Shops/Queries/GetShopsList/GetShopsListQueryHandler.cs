using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.Core.Specifications.Filters;
using Insurise.Core.Specifications.Filters.Commun.Shops;
using Insurise.Core.Specifications.Filters.Product;
using Insurise.Core.Specifications.Products;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Common;
using MediatR;

namespace Insurise.Application.Features.Common.Shops.Queries.GetShopsList;

public class GetShopsListQueryHandler : IRequestHandler<GetShopsListQuery, List<ShopDto>>
{
    private readonly IRepository<Shop> _ShopsRepository;
    private readonly IMapper _mapper;

    public GetShopsListQueryHandler(IMapper mapper, IRepository<Shop> ShopsRepository)
    {
        _mapper = mapper;
        _ShopsRepository = ShopsRepository;
    }

    public async Task<List<ShopDto>> Handle(GetShopsListQuery request, CancellationToken cancellationToken)
    {
        if (request.ProductId.HasValue)
        {
            var filter = new ProductFilter();
            filter.LoadChildren = true;
            filter.Children = new List<string> {"ProductShops"};
            var spec = new ShopSpec(filter);
            var allShops = await _ShopsRepository.ListAsync(spec, cancellationToken);
            var lstShops = _mapper.Map<List<ShopDto>>(allShops);
            //foreach (var shop in lstShops)
            //{
            //    if (shop.ListProduct.Any(x => x.Value == request.ProductId))
            //    {
            //        shop.Cheked = true;
            //    }
            //}
            return lstShops;
        }
        else
        {
            var allShops = await _ShopsRepository.ListAsync();
            return _mapper.Map<List<ShopDto>>(allShops);
        }
    }
}