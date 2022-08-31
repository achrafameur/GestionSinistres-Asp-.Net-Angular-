using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Items.Commands.UpdateItem;

public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
{
    private readonly IRepository<Item> _itemRepository;
    private readonly IMapper _mapper;

    public UpdateItemCommandHandler(IMapper mapper, IRepository<Item> itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
    {
        var itemToUpdate = await _itemRepository.GetByIdAsync(request.ItemId, cancellationToken);
        if (itemToUpdate == null) throw new ItemNotFoundException(request.ItemId);

        _mapper.Map(request, itemToUpdate, typeof(UpdateItemCommand), typeof(Item));
        await _itemRepository.UpdateAsync(itemToUpdate, cancellationToken);
        return Unit.Value;
    }
}