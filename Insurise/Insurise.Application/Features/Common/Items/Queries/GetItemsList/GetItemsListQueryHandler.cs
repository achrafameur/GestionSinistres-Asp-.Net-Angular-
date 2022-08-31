using AutoMapper;
using Insurise.Application.Features.Common.Items.Queries.GetItemDetail;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Items.Queries.GetItemsList;

public class GetItemsListQueryHandler : IRequestHandler<GetItemsListQuery, List<ItemDto>>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public GetItemsListQueryHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<List<ItemDto>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
    {
        var allItems = await _itemRepository.ListAsync(cancellationToken);
        return _mapper.Map<List<ItemDto>>(allItems);
    }
}