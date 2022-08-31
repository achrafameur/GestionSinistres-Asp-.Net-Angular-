using AutoMapper;
using Insurise.Core.Entities.Common;
using Insurise.SharedKernel.Interfaces;
using MediatR;

namespace Insurise.Application.Features.Production.Fees.Queries.GetFeesDetail;

public class GetFeesDteailQueryHandler : IRequestHandler<GetFeesDetailQuery, FeesDto>
{
    private readonly IRepository<Fee> _feesRepository;

    private readonly IMapper _mapper;

    public GetFeesDteailQueryHandler(IMapper mapper, IRepository<Fee> feesRepository)
    {
        _mapper = mapper;
        _feesRepository = feesRepository;
    }

    public async Task<FeesDto> Handle(GetFeesDetailQuery request, CancellationToken cancellationToken)
    {
        var fee = await _feesRepository.GetByIdAsync(request.feesId);
        var returnedFee = _mapper.Map<FeesDto>(fee);

        return returnedFee;
    }
}