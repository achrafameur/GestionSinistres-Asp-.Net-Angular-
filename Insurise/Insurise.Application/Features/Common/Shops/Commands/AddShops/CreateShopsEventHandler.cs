using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Common.Shops.Commands.AddShops;

public class CreateShopsEventHandler : IRequestHandler<CreateShopsCommand, int>
{
    private readonly IRepository<Shop> _ShopsRepository;
    private readonly IMapper _mapper;

    public CreateShopsEventHandler(IMapper mapper, IRepository<Shop> ShopsRepository)
    {
        _mapper = mapper;
        _ShopsRepository = ShopsRepository;
    }

    public async Task<int> Handle(CreateShopsCommand request, CancellationToken cancellationToken)
    {
        var Shop = _mapper.Map<Shop>(request);
        @Shop = await _ShopsRepository.AddAsync(Shop);

        return @Shop.Id;
    }
}