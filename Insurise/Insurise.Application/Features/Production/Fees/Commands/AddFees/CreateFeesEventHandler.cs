using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Fees.Commands.AddFees;

public class CreateFeesEventHandler : IRequestHandler<CreateFeesCommand, int>
{
    private readonly IRepository<Fee> _feesRepository;
    private readonly IMapper _mapper;

    public CreateFeesEventHandler(IMapper mapper, IRepository<Fee> feesRepository)
    {
        _mapper = mapper;
        _feesRepository = feesRepository;
    }

    public async Task<int> Handle(CreateFeesCommand request, CancellationToken cancellationToken)
    {
        var fee = _mapper.Map<Fee>(request);
        @fee = await _feesRepository.AddAsync(fee);

        return @fee.Id;
    }
}