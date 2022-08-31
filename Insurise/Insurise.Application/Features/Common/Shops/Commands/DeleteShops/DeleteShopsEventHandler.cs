using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Shops.Commands.DeleteShops;

public class DeleteShopsEventHandler : IRequestHandler<DeleteShopsCommand>
{
    private readonly IRepository<Shop> _shopsRepository;

    public DeleteShopsEventHandler(IRepository<Shop> shopsRepository)
    {
        _shopsRepository = shopsRepository;
    }

    public async Task<Unit> Handle(DeleteShopsCommand request, CancellationToken cancellationToken)
    {
        var shopToDelete = await _shopsRepository.GetByIdAsync(request.ShopId, cancellationToken);

        if (shopToDelete == null) throw new ShopNotFoundException(request.ShopId);

        await _shopsRepository.DeleteAsync(shopToDelete, cancellationToken);

        return Unit.Value;
    }
}