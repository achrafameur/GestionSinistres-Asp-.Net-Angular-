using InsuriseDTO.Common;
using MediatR;

namespace Insurise.Application.Features.Common.Shops.Queries.GetShopsDetail;

public class GetShopsDetailQuery : IRequest<ShopDto>
{
    public GetShopsDetailQuery(int id)
    {
        ShopId = id;
    }

    public int ShopId { get; }
}