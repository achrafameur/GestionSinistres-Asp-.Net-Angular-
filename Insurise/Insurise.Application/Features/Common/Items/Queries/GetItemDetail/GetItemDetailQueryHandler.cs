using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Items.Queries.GetItemDetail;

public class GetItemDetailQueryHandler : IRequestHandler<GetItemDetailQuery, ItemDto>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public GetItemDetailQueryHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<ItemDto> Handle(GetItemDetailQuery request, CancellationToken cancellationToken)
    {
        var item = await _itemRepository.GetByIdAsync(request.Id, cancellationToken);
        var itemDetailDto = _mapper.Map<ItemDto>(item);
        return itemDetailDto;
    }
}