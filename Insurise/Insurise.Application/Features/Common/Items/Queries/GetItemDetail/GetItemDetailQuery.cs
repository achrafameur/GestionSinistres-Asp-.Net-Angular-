using MediatR;

namespace Insurise.Application.Features.Common.Items.Queries.GetItemDetail;

public class GetItemDetailQuery : IRequest<ItemDto>
{
    public GetItemDetailQuery(int id)
    {
        Id = id;
    }

    public int Id { get; }
}