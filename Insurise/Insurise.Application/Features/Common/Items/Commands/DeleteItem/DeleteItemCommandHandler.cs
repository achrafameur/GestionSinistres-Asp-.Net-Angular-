using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Items.Commands.DeleteItem;

public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
{
    private readonly IRepository<Item> _itemRepository;


    public DeleteItemCommandHandler(IRepository<Item> itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
    {
        var itemToDelete = await _itemRepository.GetByIdAsync(request.ItemId, cancellationToken);

        if (itemToDelete == null) throw new ItemNotFoundException(request.ItemId);
        await _itemRepository.DeleteAsync(itemToDelete, cancellationToken);
        return Unit.Value;
    }
}