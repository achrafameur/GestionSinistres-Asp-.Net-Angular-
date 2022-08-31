using AutoMapper;
using Insurise.Application.Exceptions;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;
using Unit = MediatR.Unit;

namespace Insurise.Application.Features.Common.Shops.Commands.UpdateShops;

public class UpdateShopsEventHandler : IRequestHandler<UpdateShopsCommand>
{
    private readonly IRepository<Shop> _shopsRepository;
    private readonly IMapper _mapper;

    public UpdateShopsEventHandler(IMapper mapper, IRepository<Shop> shopsRepository)
    {
        _mapper = mapper;
        _shopsRepository = shopsRepository;
    }

    public async Task<Unit> Handle(UpdateShopsCommand request, CancellationToken cancellationToken)
    {
        var shopToUpdate = await _shopsRepository.GetByIdAsync(request.ShopId, cancellationToken);

        if (shopToUpdate == null) throw new ShopNotFoundException(request.ShopId);

        _mapper.Map(request, shopToUpdate, typeof(UpdateShopsCommand), typeof(Shop));

        await _shopsRepository.UpdateAsync(shopToUpdate, cancellationToken);

        return Unit.Value;
    }
}