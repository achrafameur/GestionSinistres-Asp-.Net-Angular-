using Insurise.Application.Features.Common.Items.Queries.GetItemDetail;
using MediatR;

namespace Insurise.Application.Features.Common.Items.Queries.GetItemsList;

public class GetItemsListQuery : IRequest<List<ItemDto>>
{
}