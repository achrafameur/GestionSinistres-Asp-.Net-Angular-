using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Items.Commands.CreateItem;

public class CreateItemCommandHandler : IRequestHandler<CreateItemCommand, int>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public CreateItemCommandHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<int> Handle(CreateItemCommand request, CancellationToken cancellationToken)
    {
        var item = _mapper.Map<Item>(request);
        item = await _itemRepository.AddAsync(item, cancellationToken);
        return item.Id;
    }
}