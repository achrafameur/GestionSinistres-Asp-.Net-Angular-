using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using InsuriseDTO.Common;
using MediatR;

namespace Insurise.Application.Features.Common.Shops.Queries.GetShopsDetail;

public class GetShopsDteailQueryHandler : IRequestHandler<GetShopsDetailQuery, ShopDto>
{
    private readonly IRepository<Shop> _ShopsRepository;

    private readonly IMapper _mapper;

    public GetShopsDteailQueryHandler(IMapper mapper, IRepository<Shop> ShopsRepository)
    {
        _mapper = mapper;
        _ShopsRepository = ShopsRepository;
    }

    public async Task<ShopDto> Handle(GetShopsDetailQuery request, CancellationToken cancellationToken)
    {
        var Shop = await _ShopsRepository.GetByIdAsync(request.ShopId);
        var returnedShop = _mapper.Map<ShopDto>(Shop);

        return returnedShop;
    }
}